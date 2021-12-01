using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points;
    [Range (1, 3)] public int hitsToBreak;
    public Sprite[] hitSprite;
    //public Color[] hitSpriteColor;

    public void Awake()
    {
        switch (hitsToBreak)
        {
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = hitSprite[2]; 
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = hitSprite[1]; 
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = hitSprite[0]; 
                break;
        }
    }

    public void BreakBrick()
    {
        hitsToBreak--;

        // change the sprite & its color when object is hit (might make it an if statement in the future (David) 
        //this.GetComponent<SpriteRenderer>().color = hitSpriteColor; 
        //this.GetComponent<SpriteRenderer>().sprite = hitSprite;

        switch(hitsToBreak)
        {
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = hitSprite[2];
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = hitSprite[1];
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = hitSprite[0];
                break;
        }
    }
}
