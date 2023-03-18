using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
// By Phatdumpling
public class Spin_self : MonoBehaviour
{
    // Alot of variables idk bro
    
    
    public RectTransform thisObj;

    private float Rx;
    private float Ry;
    private float Rz;

    private float RSxMin;
    private float RSyMin;
    private float RSzMin;
    
    private float RSxMax;
    private float RSyMax;
    private float RSzMax;
    
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
            Rotateframe();
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

        Rx = RotateDecide();
        Ry = RotateDecide();
        Rz = RotateDecide();

        RSxMin = RotateSpeedDecideMin();
        RSyMin = RotateSpeedDecideMin();
        RSzMin = RotateSpeedDecideMin();

        RSxMax = RotateSpeedDecideMax();
        RSyMax = RotateSpeedDecideMax();
        RSzMax = RotateSpeedDecideMax();

        theOBJpos = the_OBJ.transform;
        theOBJ_OriginalPos = theOBJpos.position;
        gss = glitched_sprites.Count - 1;
    }

    private float RotateDecide() // Gives a rotation direction randomly
    {
        if (Random.Range(0, 10) > 5)
        {
            return 1;
        }
        return -1;
    }

    private float RotateSpeedDecideMax() // Gives a max rotation speed randomly
    {
        return Random.Range(0, 15);
    }
    
    private float RotateSpeedDecideMin() // Gives a min rotation speed randomly,
                                         // it is negative so that the sprite
                                         // moves erratically
    {
        return Random.Range(0, -7);
    }

    
    private void Rotateframe() // Rotates sprite every frame in fixed update
    {
        thisObj.Rotate(Random.Range(RSxMin*Rx, RSxMax*Rx),Random.Range(RSyMin*Ry, RSyMax*Ry),Random.Range(RSzMin*Rz, RSzMax*Rz));
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
        return new Vector3(Random.Range(0, 150), Random.Range(0, 150),Random.Range(0, 150));
    }
}
