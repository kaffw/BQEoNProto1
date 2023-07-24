using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
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
    [SerializeField] private float jumpForce = 17.5f;//17.5f;

    private Vector3 respawnPoint;
    private Vector2 portalExit;
    //public GameObject fallDetector;

    public static int deathCounter = 0;
    public static bool immunity = false;

    //og from Playermovement.cs
    //idk
    private BoxCollider2D coll;

    //dash
    public bool FacingRight = true;
    public bool canDash = true;
    public static bool isDashing;
    public bool isWallSliding;

    //variables for LedgeClimb
    [HideInInspector]public bool LedgeDetected;
    [Header("Ledge Info")]
    [SerializeField] private Vector2 offset1;
    [SerializeField] private Vector2 offset2;
    private Vector2 climbBegunPosition;
    private Vector2 climbOverPosition;
    private bool canGrabLedge = true;
    private bool canClimb; 



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


    //double jump
    private bool doubleJump;
    [SerializeField] private float doubleJumpingPower = 17.5f;



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

    public static int ActLocation = 0;

    //hit immunity
    public static float hitImmunityDuration = 1.5f;
    public static bool isImmune = false;

    private void Awake()
    {
        if (CharacterPositionManager.ifFromEntrance == true)
        {
            //transform.position = CharacterPositionManager.exitPosition;
            
            if(ActLocation == 1) transform.position = CharacterPositionManager.exitPosition;
            if(ActLocation == 2) transform.position = CharacterPositionManager.exitPositionAct2;
        }
        else
        {
            //transform.position = CharacterPositionManager.entrancePosition;
            if(ActLocation == 1) transform.position = CharacterPositionManager.entrancePosition;
            if(ActLocation == 2) transform.position = CharacterPositionManager.entrancePositionAct2;
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

        isFiring = false;
        fireRateTimer = 0;
    }

    private void Update()
    {
        isShielded();
        WallSlide();
        WallJump();

        if (FallTrap.fell == true)
        {
            transform.position = respawnPoint;
            FallTrap.fell = false;
        }

        if (immunity == true)
        {
            StartCoroutine(ImmunityDuration());
        }

        if (isDashing)
        {
            return;
        }

        dirX = Input.GetAxisRaw("Horizontal");

        if (!Dialogue.inDialogue && !shielded)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                doubleJump = false;

            }
            if (Input.GetButtonDown("Jump") && !Dialogue.inDialogue) //&& IsGrounded()
            {
                if (IsGrounded() || doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, doubleJump ? doubleJumpingPower : jumpForce);
                    doubleJump = !doubleJump;
                }
            }

            // newly added
            if (Input.GetKeyDown("k") && canDash)
            {
                isImmune = true;
                hitImmunityDuration = 1f;
                StartCoroutine(Dash());
                anim.SetTrigger("dash");
            }

            if (horizontalMove > 0f)
            {
                anim.SetInteger("state", 1);
            }
            else if (horizontalMove < 0f)
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
            UpdateAnimationState();
            fireRateTimer += Time.deltaTime;
            if (Input.GetKeyDown("u") && fireRateTimer >= fireRate && !isFiring)
            {
                isFiring = true;
                anim.SetTrigger("CombatRanged");
                StartCoroutine(DelayFire());
            }
        }
        ActLocator();

        if (isImmune)
        {
            hitImmunityDuration -= Time.deltaTime;

            if (hitImmunityDuration <= 0f)
            {
                isImmune = false;
                // Re-enable collision and damage processing here
            }
        }
        //Debug.Log(ActLocation);
        //falldetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

    }

    //above Playermovement.cs UpdateAnimationState...

    private void CheckForLedge(){
        if(LedgeDetected&& canGrabLedge){
            canGrabLedge = false;

            Vector2 ledgePosition = GetComponentInChildren<LedgeDetection>().transform.position;

            climbBegunPosition = ledgePosition + offset1;
            climbOverPosition = ledgePosition + offset2;
            canClimb = true;
        }
        if(canClimb){

            transform.position = climbBegunPosition;
        }
    }


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
            isImmune = true;
            hitImmunityDuration = 3f;

            rb.velocity = new Vector2(0, 0);
            anim.SetBool("Shield", true);
            shield.SetActive(true);
            shielded = true;
            Invoke("notShielded", 2f); //3f prev
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
            FacingRight = !FacingRight;
            transform.Rotate(0f, 180f, 0f);
            dirFire = true;
        }

        else if (dirX < 0f && FacingRight && !isWallJumping)// && !isWallJumping)
        {
            FacingRight = !FacingRight;
            transform.Rotate(0f, 180f, 0f);
            dirFire = false;
        }

        if (rb.velocity.y > 0.1)
        {
            //state = MovementState.jumping;
            //PlayerVariable.isJumping = true;
            isJumping = true;
            anim.SetInteger("state", 2);
        }

        else if (rb.velocity.y < -0.1)
        {
            //state = MovementState.falling;
            anim.SetInteger("state", 3);
        }

        //if (rb.velocity.x == 0 && rb.velocity.y == 0 && CombatMelee.inAttack == false) anim.SetInteger("state", 0);
        //else anim.SetInteger("state", 0);
        //anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector" && !shielded && !immunity)
        {
            transform.position = respawnPoint;
        }
        else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }

        if (collision.tag == "Portal")
        {
            transform.position = portalExit;
        }
        else if (collision.tag == "PortalExit")
        {
            portalExit = new Vector2(transform.position.x, transform.position.y + 30);
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position,0.2f,wallLayer);
    }

    private void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = - transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {

            wallJumpingCounter = -Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump")&&wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection*8f,17.5f);
            wallJumpingCounter = 0f;

            if(transform.localScale.x !=wallJumpingDirection)
            {

                FacingRight = !FacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *=-1f;
                transform.localScale =localScale;
            }
            Invoke(nameof(StopWallJumping),wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping= false;
    }

    private void WallSlide()
    {
        if(IsWalled()&& !IsGrounded()&& horizontalMove != 0f)
        {
            isWallSliding= true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed,float.MaxValue));
            if(isWallSliding == true) {anim.SetTrigger("WallSliding");}

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
            Instantiate(PseudoBulletProjectile, new Vector2(rb.transform.position.x + 1, rb.transform.position.y), Quaternion.identity); //transform.rotation
            fireRateTimer = 0f;
        }
        else
        {
            Instantiate(PseudoBulletProjectile, new Vector2(rb.transform.position.x - 1, rb.transform.position.y), Quaternion.identity); //transform.rotation
            fireRateTimer = 0f;
        }

        yield return new WaitForSeconds(0.75f);
        isFiring = false;
    }

    private void ActLocator()
    {
        /*if (MapSequenceInitializer.entryToAct2 == true)
        {
            ActLocation = 2;
        }
        if (MapSequenceInitializer.entryToAct3 == true)
        {
            ActLocation = 3;
        }
        */
    }

    private IEnumerator ImmunityDuration()
    {
        Debug.Log("Start of Iframe");
        yield return new WaitForSeconds(3f); //3 f prev
        Debug.Log("End of Iframe");
        immunity = false;
    }
}