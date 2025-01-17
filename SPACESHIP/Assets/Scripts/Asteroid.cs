﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        float speedChanger = ScoreManager.scoreCount / 1000;
        if ( speedChanger >1)
        {
            rb.velocity = new Vector2(-(speed + speedChanger), 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    /*void Update()
    {
        if (transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }*/
}