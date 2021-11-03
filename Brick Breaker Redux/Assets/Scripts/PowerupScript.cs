using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    // controls the speed of the powerup
    public float speed = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // speeds the paddle down
        transform.Translate(new Vector2(0f, -1) * Time.deltaTime * speed);


        // if powerup leaves the screen, destroy it
        if (transform.position.y < -7f)
            Destroy(this.gameObject);
    }
}
