using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ov : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private PlayerAnimation playerAnimation;
    public float movespeed = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = FindObjectOfType<PlayerAnimation>();
    }

    private void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        Vector2 InputVector = new Vector2(moveH, moveV).normalized * movespeed * Time.fixedDeltaTime;
        
        rb.MovePosition(currentPos + InputVector);

        playerAnimation.SetDirection(new Vector2(moveH, moveV));
    }
    
    
}
