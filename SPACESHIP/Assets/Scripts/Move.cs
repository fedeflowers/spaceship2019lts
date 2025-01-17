﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX, dirY;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
            dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
            dirY = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }
}
