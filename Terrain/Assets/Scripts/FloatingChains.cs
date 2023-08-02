using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatingChains : MonoBehaviour
{
    public GameObject relic;
    public Rigidbody2D relicRB;
    private float timer = 0f;
    private float levitateSpeed = .5f;
    private bool up = false;
    void Start()
    {
        relicRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (up == true)
        {
            relicRB.transform.position = new Vector2(relicRB.transform.position.x, relic.transform.position.y - Time.deltaTime * levitateSpeed);
            if (timer > 1f)
            {
                timer = 0f;
                up = false;
            }
        }

        if (up == false)
        {
            relicRB.transform.position = new Vector2(relicRB.transform.position.x, relic.transform.position.y + Time.deltaTime * levitateSpeed);
            if (timer > 1f)
            {
                timer = 0f;
                up = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D pick)
    {
        if (pick.CompareTag("Player"))
        {
            Debug.Log("Relic has been picked up");
            StartCoroutine(ActChangeScene());
            //SceneManager.LoadScene(28);
        }
    }
    
    private IEnumerator ActChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(28);
        Destroy(gameObject, .25f);

    }
}
