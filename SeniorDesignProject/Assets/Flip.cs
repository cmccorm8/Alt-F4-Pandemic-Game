using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    //public GameObject enemy;
    public Transform enemyTransform;

    public Transform player;
    public Rigidbody2D enemyRigidbody;

    private bool enemyFlipped = false;
   

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
