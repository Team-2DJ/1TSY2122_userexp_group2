using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    public Sprite hitSprite;
    public Color hitSpriteColor; 

    public void BreakBrick()
    {
        hitsToBreak--;

        // change the sprite & its color when object is hit (might make it an if statement in the future (David) 
        this.GetComponent<SpriteRenderer>().color = hitSpriteColor; 
        this.GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
}
