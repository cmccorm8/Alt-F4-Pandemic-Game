using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    //public GameObject enemy;
    public Transform enemyTransform;
    public Rigidbody2D enemyRigidbody;

    //GB: dummy enemy switches the direction of his velocity every 
    //    half second or so regardless of the direction it's actually
    //    walking in so I'm trying to account for that with a counter
    //    making sure the image doesn't flip just because the A* algo 
    //    is acting weird.
    private int counter; 

    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = enemyRigidbody.velocity;
        Vector3 enemyScale = enemyTransform.localScale;

        if ((velocity[0] < 0 && enemyScale[0] > 0) || (velocity[0] > 0 && enemyScale[0] < 0))
        {
            counter++;
        }

        if(counter > 20)
        {
            counter = 0;
            enemyScale[0] = -enemyScale[0];
            enemyTransform.localScale = enemyScale;
        }
        /*else if (velocity > 0 && enemyScale < 0)
        {
            enemyScale[0] = -enemyScale[0];
        }*/
    }
}
