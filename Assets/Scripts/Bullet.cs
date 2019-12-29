﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
   public float velo;
   public GameObject explosion;
    public PlayerController player;
    private void Awake()
    {
     player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * velo;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);           
            Destroy(this.gameObject);
            player.score=player.score+1;
        }
        Destroy(this.gameObject);
    }

   
}