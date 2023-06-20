using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_ov : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private PlayerAnimation playerAnimation;
    public float movespeed = 1.0f;
    public TextMeshProUGUI MyScoreText;
    private int ScoreNum;
 //   public AudioSource Soundbimyeug;

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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.transform.CompareTag("Treasure"))
        {
            ScoreNum += 1;
            Destroy(other.gameObject);
            MyScoreText.text = "발견한 상자 : " + ScoreNum;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bora"))
        {
            Health.health -= 84f;
           // Debug.Log("보라돌이에게 공격 잡혔습니다.");
            
            if (Health.health <= 0f)
            {
                Debug.Log("보라돌이에게 공격 잡혔습니다.");
                Time.timeScale = 0f;
                //Debug.Log("보라돌이에게 공격 잡혔습니다.");
            }
        }
        
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
    //   else if (collision.gameObject.CompareTag("Car"))
     //   {
           // SoundCar.Play();
       // }
        
    //}
    
}
