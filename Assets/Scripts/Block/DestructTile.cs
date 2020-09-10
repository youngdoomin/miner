﻿using System.Collections;
using UnityEngine;
public class DestructTile : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer tileSp;
    public static bool tileBreak = false;
    void Start()
    {
        tileSp = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && tileSp.color.a == 1)
        {
            StartCoroutine(Destruct());
        }
    }

    private void OnEnable()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public IEnumerator Destruct()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        tileBreak = true;
        Debug.Log("파괴");
        if (this.gameObject.tag == "Platform_jam")
        { this.gameObject.SendMessage("SpawnJam"); }


        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).SendMessage("ParticlePlay");
        tileSp.color = new Color(1, 1, 1, 0);
        yield return null;
    }
}
