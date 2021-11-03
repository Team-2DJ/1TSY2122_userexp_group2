using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    public Sprite hitSprite;

    public void BreakBrick()
    {
        hitsToBreak--;

        // change the sprite & its color when object is hit (might make it an if statement in the future (David) 
        this.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 152f / 255f, 66f / 255f);
        this.GetComponent<SpriteRenderer>().sprite = hitSprite;
    }
}
