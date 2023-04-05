using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
// By Phatdumpling
public class Dead_glitched : MonoBehaviour
{
    // Alot of variables idk bro
    
    
    public RectTransform thisObj;

    public List<Sprite> glitched_sprites = new List<Sprite>();
    public Sprite original_sprite;
    private int zero = 0;
    private int gss;

    public GameObject the_OBJ;
    private Transform theOBJpos;
    private Vector3 theOBJ_OriginalPos;

    private int counter = 0;
    private bool glitched = false;
    private bool teleported = false;

    private void FixedUpdate() // Rotates the sprite and glitches it every frame
    {
        
        if (glitched == false) // Chance to change to glitch sprite
        {
            glitched = glitch();
        }
        else if (glitched == true) // Glitch phase it teleports around
        {
            counter += 1;

            if (counter % 3 == 0)
            {
                fixedTeleport();
            }
            
        }
        if (counter >= 15) //Glitch state lasts for 15 frame or 0.25 sec
        {
            glitched = false;
            the_OBJ.GetComponent<Image>().sprite = original_sprite;
            theOBJpos.position = theOBJ_OriginalPos;
        }

    }

    private void Start() // Setting variables, random every game
    {
        theOBJpos = the_OBJ.transform;
        theOBJ_OriginalPos = theOBJpos.position;
        gss = glitched_sprites.Count - 1;
    }
    

    
    private bool glitch() // Gets random glitched sprite 1% chance every frame
    {
        if (Random.Range(0, 100) == 1)
        {
            the_OBJ.GetComponent<Image>().sprite = glitched_sprites[Random.Range(zero, gss)];
            counter = 0;
            return true;
        }

        return false;
    }

    
    private void fixedTeleport() // Teleports to a random position back and forth
    {
        if (teleported == false)
        {
            theOBJpos.position += randomTeleport();
            teleported = true;
        }
        else
        {
            theOBJpos.position = theOBJ_OriginalPos;
            teleported = false;
        }
    }

    
    private Vector3 randomTeleport() // Gives a random vector 3 direction to teleport in
    {
        return new Vector3(Random.Range(-150, 150), Random.Range(-150, 150),Random.Range(-150, 150));
    }
}
