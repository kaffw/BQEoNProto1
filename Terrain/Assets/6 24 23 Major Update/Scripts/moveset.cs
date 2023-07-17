using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveset : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    public static bool isFiring = false;
    public GameObject PseudoBulletProjectile;
    public static bool dirFire = true;
    public float fireRate = 1f;
    public float fireRateTimer = 0f;

    //movement
    public static float dirX = 0f;
    public float horizontalMove = 0f;                   //from Playermovement.cs
    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] private float jumpForce = 17.5f;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    public static int deathCounter = 0;

    //og from Playermovement.cs
    //idk
    private BoxCollider2D coll;

    //dash
    public bool FacingRight = true;
    public bool canDash = true;
    public bool isDashing;
    public bool isWallSliding;

    private float wallSlidingSpeed = 2f;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    //wall jump
    public bool isWallJumping;
    public float wallJumpingDirection;
    public float wallJumpingTime = 0.2f;
    public float wallJumpingCounter;
    public float wallJumpingDuration = 0.4f;

    //ground
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck;


    //shield
    public static bool shielded;
    [SerializeField] private GameObject shield;

    public static bool isJumping, isGrabbing; //from PlayerVariable.cs moved to moveset.cs

    //private enum MovementState { idle, running, jumping, falling }
    //private MovementState state = MovementState.idle;

    private void Awake()
    {
        if (CharacterPositionManager.ifFromEntrance == true)
        {
            transform.position = CharacterPositionManager.exitPosition;
        }
        else
        {
            transform.position = CharacterPositionManager.entrancePosition;
        }

        CharacterPositionManager.ifFromEntrance = false;
    }

    private void Start()
    {
        shielded = false;                           //from Playermovement.cs
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();       //from Playermovement.cs
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    private void Update()
    {
        isShielded();
        WallSlide();
        WallJump();

        if (isDashing)
        {
            return;
        }

        dirX = Input.GetAxisRaw("Horizontal");
       horizontalMove = Input.GetAxisRaw("Horizontal");
        if (!Dialogue.inDialogue && !shielded) rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !Dialogue.inDialogue)// && IsGrounded()) //&& IsGrounded()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // newly added
        if (Input.GetKeyDown("z") && canDash)
        {
            StartCoroutine(Dash());
            anim.SetTrigger("dash");
        }

        if (horizontalMove > 0f)
        {
            anim.SetInteger("state", 1);
        }
        else if (horizontalMove< 0f)
        {
            anim.SetInteger("state", 1);
        }
        else if (IsGrounded())
        {
            anim.SetInteger("state", 4);
        }
        else
        {
            anim.SetInteger("state", 0);
        }

        fireRateTimer += Time.deltaTime;
        if (Input.GetKeyDown("j") && fireRateTimer >= fireRate && !isFiring)
        {
            isFiring = true;
            anim.SetTrigger("CombatRanged");
            StartCoroutine(DelayFire());
        }

        UpdateAnimationState();

        //falldetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

    }

    //above Playermovement.cs UpdateAnimationState...

    private IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        if (!FacingRight)
        {
            rb.velocity = new Vector2(-dashingPower, 0f);
        }

        else
        {
            rb.velocity = new Vector2(dashingPower, 0f);
        }

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);

        canDash = true;

    }

    public void isShielded()
    {

        if (Input.GetKeyDown("e") && !shielded)
        {
            rb.velocity = new Vector2(0, 0);
            anim.SetBool("Shield", true);
            shield.SetActive(true);
            shielded = true;
            Invoke("notShielded", 3f);
        }

    }

    public void notShielded()
    {
        shield.SetActive(false);
        anim.SetBool("Shield", false);
        shielded = false;
    }

    //Playermovement.cs

    private void UpdateAnimationState()
    {
        //MovementState state;
        if (dirX > 0f && !FacingRight && !isWallJumping)// && !isWallJumping)
        {
            //state = MovementState.running;
            /*sprite.flipX = true;
            FacingRight = !FacingRight;
            dirFire = true;*/
            FacingRight = !FacingRight;
            transform.Rotate(0f, 180f, 0f);
            dirFire = true;
        }

        else if (dirX < 0f && FacingRight && !isWallJumping)// && !isWallJumping)
        {
            //state = MovementState.running;
            /*sprite.flipX = false;
            FacingRight = !FacingRight;
            dirFire = false;*/
            FacingRight = !FacingRight;
            transform.Rotate(0f, 180f, 0f);
            dirFire = false;
        }

        //else state = MovementState.idle;

        if (rb.velocity.y > 0.1f)
        {
            //state = MovementState.jumping;
            //PlayerVariable.isJumping = true;
            isJumping = true;
            anim.SetInteger("state", 2);
        }

        else if (rb.velocity.y < -0.1f)
        {
            //state = MovementState.falling;
            anim.SetInteger("state", 3);
        }

        //anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector" && !shielded)
        {
            deathCounter++;
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {

            wallJumpingCounter = -Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * 8f, 8f);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {

                FacingRight = !FacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontalMove != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            if (isWallSliding == true) { anim.SetTrigger("WallSliding"); }

        }

        else
        {
            isWallSliding = false;
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private IEnumerator DelayFire()
    {
        yield return new WaitForSeconds(0.25f);
        if (dirFire && fireRateTimer >= fireRate)
        {
            Instantiate(PseudoBulletProjectile, new Vector2(rb.transform.position.x + 1, rb.transform.position.y), transform.rotation);
            fireRateTimer = 0f;
        }
        else
        {
            Instantiate(PseudoBulletProjectile, new Vector2(rb.transform.position.x - 1, rb.transform.position.y), transform.rotation);
            fireRateTimer = 0f;
        }

        yield return new WaitForSeconds(0.75f);
        isFiring = false;
    }


}