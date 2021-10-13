using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the Rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the ball is off-screen and not in play,
        // put the ball back to the paddle
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        // If Space Bar is pressed,
        // start the ball's movement
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;

            // Adds upward force to the ball
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            Debug.Log("Ball hit the bottom of the screen");

            // Sets the momentum of the ball to zero
            rb.velocity = Vector2.zero;

            // Puts the ball back to the paddle
            inPlay = false;
        }
    }
}
