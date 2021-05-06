using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float enemyMvmtSpeed = 200f;
    protected Rigidbody2D rb2D;
    protected Vector2 direction;
    protected Vector2 npcForce;
    protected Vector2 velocity;
    private Animator animator;
    public float timeInterval = 8.0f;

    private float force;

    private int distance;

    private bool stopped = true;

    private Transform npcTransform;
    private bool npcFlipped = false;

    // Start is called before the first frame update
    public void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();     //Gets a rigidbody2d component
        npcTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        velocity = rb2D.velocity;

        enemyMvmtSpeed += Random.Range(-50.0f, 150.0f);
        if (Random.Range(0, 1) == 0)
        {
            Flip();
            npcMove();
        }
        else
        {
            npcMove();
        }
    }

    private void AnimationHandler()
    {
        float temp = velocity.x * ((velocity.x < 0) ? -1 : 1);
        animator.SetFloat("Speed", temp);
    }

    private void npcMove()
    {
        //direction = ((Vector2)enemyTarget.position - rb2D.position).normalized;
        //npcForce = direction * enemyMvmtSpeed * Time.deltaTime;       //for enemy horizontal movement

        force = ((npcFlipped) ? -1 : 1) * enemyMvmtSpeed * Time.deltaTime;

        velocity = rb2D.velocity;
        velocity.x = force;
        rb2D.velocity = velocity;

        stopped = false;
    }

    private void npcStop()
    {
        npcForce = direction * 0;       //for enemy horizontal movement

        velocity.x = 0;

        stopped = true;
    }

    private void Flip()
    {
        npcTransform.Rotate(0f, 180f, 0f);
        npcFlipped = (npcFlipped) ? false : true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (rb2D.velocity.x < 1f && rb2D.velocity.x > -1f && !stopped)
        {
            Flip();
            npcMove();
        }
        else
        {
            int random = Random.Range(0, 100);
            //print(random);
            if (random == 0)
            {
                Flip();
                npcMove();
            }
            else if (random == 1)
            {
                random = Random.Range(0, 5);
                if (random == 0) npcStop();
            }
            else if (!stopped)
            {
                npcMove();
            }

        }

        AnimationHandler();
    }

}
