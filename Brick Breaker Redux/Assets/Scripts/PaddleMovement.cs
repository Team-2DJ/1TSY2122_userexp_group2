using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    //Note Didn't Change the Collider of the Paddle
    //Paddle Speed
    public float speed;

    //Gamemanger
    public GameManager gm;
   
    //Screen Edges
    public float rightScreenEdge;
    public float leftScreenEdge;

    public Sprite blasterSprite;
    public Sprite normalPaddleSprite;

    public bool blasterIsActive = false;

    public GameObject leftNozzle;
    public GameObject rightNozzle;

    public GameObject bullet;
    public GameObject bullet2;

    public float fireRate = 5.0f;
    public float nextFire = 0f;

    public BallScript ball;

    public AudioSource pickupPowerupSound;

    // Start is called before the first frame update
    void Start()
    {
        normalPaddleSprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(ball == null)
        {
            ball = FindObjectOfType<BallScript>();

        }
        FireBullets();
        //When gameOver is true
        if (gm.gameOver)
        {
            //When true it stops the update when it gameover so now there no paddle movement
            return;
        }

        //Paddle Movement

        //Contains the horizontal movement for the paddle
        //if you press A you get -1 , if you press D you get 1, and pressing none is 0
        float horizontal = Input.GetAxis("Horizontal");

        //TRANSLATE: a method that moves the transform in the direction of the vector

        //if you press d you get a postive (1), if you press a you go left(-1), if you press none then its 0
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

        //EdgeCheck

        //When paddle position is greater then the left screen edge
        if(transform.position.x < leftScreenEdge)
        {
            //will make the position equal to the leftScreenEdge and its current y position
            transform.position = new Vector2(leftScreenEdge, transform.position.y);

        }

        //When paddle position is less then the right screen edge
        if (transform.position.x > rightScreenEdge)
        {
            //will make the position equal to the rightScreenedge and its current y position
            transform.position = new Vector2(rightScreenEdge, transform.position.y);

        }

    }

    // used for the powerup system (David) 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag) 
        { 
            case "extraLife":
                gm.updateLives(1);
                pickupPowerupSound.Play();

                break;
            case "extraBall":
                if (gm.isMultiple == false)
                {
                    ball.spawnMultipleBalls();
                }
                pickupPowerupSound.Play();
                break;

            case "extraBlaster":
                //normalPaddleSprite = blasterSprite;
                this.GetComponent<SpriteRenderer>().sprite = blasterSprite;
                blasterIsActive = true;
                pickupPowerupSound.Play();
                break;
        }

        // destroys the powerup once collided on 
        Destroy(collision.gameObject);

        /* in the future, once we add more powerups, I'll add a checker that sees if the object is a health powerup,
        "gun" powerup, ball powerup, etc. That'll not be based from the video anymore rather, our own code (David) */

    }

    void FireBullets()
    {
        if (blasterIsActive == true)
        {
            Debug.Log("Blaster Active");
            if (Input.GetKeyUp(KeyCode.Space) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject leftShot = Instantiate(bullet, leftNozzle.transform.position, leftNozzle.transform.rotation);
                GameObject rightShot = Instantiate(bullet2, rightNozzle.transform.position, rightNozzle.transform.rotation);
            }
        } else
        {
            this.GetComponent<SpriteRenderer>().sprite = normalPaddleSprite;

        }
    
    }
}
