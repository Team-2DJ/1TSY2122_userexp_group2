using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBulletMovement : MonoBehaviour
{
    public float speed = 5;


    public Transform explosion;

    // array of powerups (David)
    public Transform[] powerup;

    public GameManager gm;


    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BrickScript>())
        {
            BrickScript brick = other.gameObject.GetComponent<BrickScript>();
            // brick health, if brick health <= 0 then don't run this if statement
            if (brick.hitsToBreak > 1)
            {
                brick.BreakBrick();
                Destroy(this.gameObject);
                return;
            }

            // creates the breaking (explosion) particle effect
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);

            // Gets the points value of the brick
            gm.updateScore(brick.points);

            // Removes a brick from the level count
            gm.UpdateNumberofBricks();

            // powerup logic, checks between brick tags 
            switch (other.transform.tag)
            {
                case "HealthBrick": // if brick tag is health brick, instantiate health powerup[0]
                    Instantiate(powerup[0], other.transform.position, other.transform.rotation);
                    break;
                case "BallBrick": // if brick tag is ball brick, instantiate extra ball powerup[1]
                    Instantiate(powerup[1], other.transform.position, other.transform.rotation);
                    break;
                case "BlasterBrick": // if brick tag is blaster brick, instantiate blaster powerup[2]
                    Instantiate(powerup[2], other.transform.position, other.transform.rotation);
                    break;
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }
}
