﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private Transform enemyTarget;
    private float enemyMvmtSpeed = 300f;
    private float enemyMvmt = 0;
    protected Rigidbody2D rb2D;
    protected Vector2 direction;
    protected Vector2 enemyForce;
    protected Vector2 velocity;
    private Animator animator;
    private bool canSeePlayer = false;
    private bool playerLost = false;
    public bool enemyGrounded = true;
    public float timeInterval = 8.0f;

    private Transform enemyTransform;
    private bool enemyFlipped = false;

    // Start is called before the first frame update
    public void Start()
    {
        enemyTarget = GameObject.Find("Main Character").GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();     //Gets a rigidbody2d component
        enemyTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        velocity = rb2D.velocity;

        enemyMvmtSpeed += Random.Range(-150.0f, 150.0f);
    }

    private void AnimationHandler()
    {
        float temp = velocity.x * ((velocity.x < 0) ? -1 : 1);
        animator.SetFloat("Speed", temp);
    }

    private void enemyPursuit()
    {
        direction = ((Vector2)enemyTarget.position - rb2D.position).normalized;
        enemyForce = direction * enemyMvmtSpeed * Time.deltaTime;       //for enemy horizontal movement
        velocity = rb2D.velocity;
        velocity.x = enemyForce.x;
        rb2D.velocity = velocity;
    }
    
    private void enemyStop()
    {
        canSeePlayer = false;
        playerLost = false;

        enemyForce = direction * 0;       //for enemy horizontal movement

        velocity.x = 0;
    }

    private void Flip()
    {   //Rotates enemy based on player position
        if (enemyFlipped)
        {
            if (enemyTransform.position.x < enemyTarget.position.x)
            {
                enemyTransform.Rotate(0f, 180f, 0f);
                enemyFlipped = false;
            }

        }
        else
        {
            if (enemyTransform.position.x > enemyTarget.position.x)
            {
                enemyTransform.Rotate(0f, 180f, 0f);
                enemyFlipped = true;
            }
        }
        /*if (enemyTransform.position.x < enemyTarget.position.x && enemyFlipped)
        {
            enemyTransform.Rotate(0f, 180f, 0f);
            enemyFlipped = false;
        }
        else if (enemyTransform.position.x > enemyTarget.position.x && !enemyFlipped)
        {
            enemyTransform.Rotate(0f, 180f, 0f);
            enemyFlipped = true;
        }*/
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Flip();

        float distance = (enemyTarget.position.x - enemyTransform.position.x) * ((enemyFlipped) ? -1 : 1);

        //GB: Too many colliders were making physics take around 100ms a frame to generate so we 
        //    had to switch to this method to maintain playable framerates.
        if(distance < 10f)
        {
            enemyPursuit();
        }
        else
        {
            enemyStop();
        }

        /*if (playerLost)
        {
            enemyStop();
        }
        else if (canSeePlayer)
        {
            enemyPursuit();
        }*/

        AnimationHandler();
    }

   /*private void OnTriggerEnter2D(Collider2D collision)
    {
        *//*if(collision.tag == "ground" || collision.tag == "Obstacle")
        {
            enemyGrounded = true;
            print("Enemy is Grounded");
            
        }
        else *//*if(collision.tag == "Agro")
        {
            canSeePlayer = true;
            //enemyPursuit();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        *//*if(collision.tag == "ground" || collision.tag == "Obstacle")
        {
            enemyGrounded = false;
        }
        else *//*if(collision.tag == "Agro")
        {
            playerLost = true;
            //enemyStop();
        }
        
    }*/
}
