using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    //public GameObject enemy;
    public Transform enemyTransform;

    public Transform player;
    public Rigidbody2D enemyRigidbody;

    public bool enemyFlipped = false;
    
  

    //GB: dummy enemy switches the direction of his velocity every 
    //    half second or so regardless of the direction it's actually
    //    walking in so I'm trying to account for that with a counter
    //    making sure the image doesn't flip just because the A* algo 
    //    is acting weird.
    //private int counter; 

    void Start()
    {
        //counter = 0;
        
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
