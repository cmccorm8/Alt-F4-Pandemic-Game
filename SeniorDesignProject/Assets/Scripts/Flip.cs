using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    //public GameObject enemy;
    private Transform enemyTransform;
    private Rigidbody2D enemyRigidbody;

    public Transform player;

    private bool enemyFlipped = false;
    

    void Start()
    {
        player = GameObject.Find("Main Character").GetComponent<Transform>();

        enemyTransform = GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = enemyRigidbody.velocity;
        Vector3 enemyScale = enemyTransform.localScale;
        
        //Rotates enemy based on player position
        if(enemyTransform.position.x < player.position.x && enemyFlipped)
        {
            enemyTransform.localScale = enemyScale;
            enemyTransform.Rotate(0f, 180f, 0f);
            enemyFlipped = false;
        }
        else if(enemyTransform.position.x > player.position.x && !enemyFlipped)
        {
            enemyTransform.localScale = enemyScale;
            enemyTransform.Rotate(0f, 180f, 0f);
            enemyFlipped = true;
        }



    }
}
