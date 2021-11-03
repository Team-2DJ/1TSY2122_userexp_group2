using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;

    // temporarily only accepts one powerup (extra life), will be changed into an array come the time we will add more powerups (David)
    public Transform powerup; 

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the Rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //When gameover is true
        if(gm.gameOver)
        {
            //When true it stops the update when it gameover so no more ball
            return;
        }
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

            // Decrease lives by 1
            gm.updateLives(-1);
        }
    }

    // Added in a collider for when the ball hits the bricks (David) 
    private void OnCollisionEnter2D(Collision2D other)
    {
        // if ball collides with an object with tag "brick", destroys the brick 
        if (other.transform.CompareTag("Brick"))
        {
            BrickScript brick = other.gameObject.GetComponent<BrickScript>();

            // brick health, if brick health <= 0 then don't run this if statement
            if (brick.hitsToBreak > 1)
            {
                brick.BreakBrick();
                return; 
            }

            // random Number to check if powerup should be called
            /* To Note: I might change this system if we're done with the video tutorial, might make it a brick thing wherein if 
            this brick is broken, then drop powerup, but for now this system will do (David) */

            int randomChance = Random.Range(1, 101);

            if (randomChance < 50) // 50% chance of spawning
            {
                Instantiate(powerup, other.transform.position, other.transform.rotation);
            }

            // creates the breaking (explosion) particle effect
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);

            // Gets the points value of the brick
            gm.updateScore(brick.points);

            // Removes a brick from the level count
            gm.UpdateNumberofBricks();

            Destroy(other.gameObject);
        }
    }
}