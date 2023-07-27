using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBG : MonoBehaviour
{
    public GameObject dynamicBackground;
    public Rigidbody2D dynamicBackgroundRB;
    public GameObject Target;

    private Vector3 initialPosition;

    void Start()
    {
        Target = GameObject.Find("Bulan");
        dynamicBackgroundRB = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Store the initial position
    }

    void Update()
    {
        // Calculate the offset from the initial position to the target position
        float offsetX = (Target.transform.position.x - initialPosition.x) / 30f;

        // Use the calculated offset to update the background's position
        transform.position = new Vector3(initialPosition.x - offsetX, initialPosition.y, initialPosition.z);
    }
}
