﻿using UnityEngine;

public class Jam_ReturnSprite : MonoBehaviour
{
    public static int jamCt = 0;
    public static bool getJam;
    public Sprite UI_img;
    public int jamID;
    public static Sprite cJamUI;
    //private AudioSource SE;
    //public AudioClip jamSE;
    /*
    private void Start()
    {
        SE = gameObject.AddComponent<AudioSource>();
        SE.clip = jamSE;
        SE.loop = false;
    }
    */
    void Update()
    {

        /*
        if(DestructTile.tileBreak == false)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }*/
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            //SE.Play();
            JamReturn();
        }
    
    }

    void JamReturn()
    {
        getJam = true;
        var jamSpawn = GameObject.FindGameObjectWithTag("JamSpawn");
        jamSpawn.SendMessage("Pickup", jamID);

        //jamSpawn.SendMessage("Pickup", this);
        if (JamUI.repeat == false)
        {
            jamCt++;
        }
        cJamUI = UI_img;
        JamUI.spriteToUI(jamCt);
        Destroy(gameObject);

    }
}