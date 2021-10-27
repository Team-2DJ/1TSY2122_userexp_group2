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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
