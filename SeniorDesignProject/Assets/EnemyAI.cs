using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform enemyTarget;
    public Transform player;

    public float enemyMvmtSpeed = 200f;
    public float enemyMvmt = 0;
    public float nxtWayPoint = 3f;

    Path path;
    int currWayPoint = 0;
    bool endOfPath = false;

    Seeker harryPotter;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        harryPotter = GetComponent<Seeker>();   //Gets a A* seeker component
        rb2D = GetComponent<Rigidbody2D>();     //Gets a rigidbody2d component

        InvokeRepeating("PathUpdate", 0f, .5f); // continuously updates the path
        
    }

    void PathUpdate()       //Invoked by InvokeRepeating to test if pathfinding is complete. if not updates the path
    {
        if(harryPotter.IsDone())
        {
            harryPotter.StartPath(rb2D.position, enemyTarget.position, PathComplete);
        }
    }

    void PathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null) // if no path return null
        {
            return;
        }
        if(currWayPoint >= path.vectorPath.Count) // check if currWayPoint is at the end of calculated path
        {
            endOfPath = true;
            return;
        }
        else
        {
            endOfPath = false;              //have not reached end of path
        }

        Vector2 direction =((Vector2)path.vectorPath[currWayPoint] - rb2D.position).normalized;
        Vector2 enemyForce = direction * enemyMvmtSpeed * Time.deltaTime;       //for enemy horizontal movement
        Vector2 velocity = rb2D.velocity;

        /*Vector3 enemyScale = enemyTarget.localScale;

        if (direction[0] < 0)
        {
            if (enemyScale[0] > 0)
            {
                enemyScale[0] = -enemyScale[0];
                enemyTarget.localScale = enemyScale;
            }
        }
        else if (direction[0] >= 0)
        {
            if(enemyScale[0] < 0)
            {
                {
                    enemyScale[0] = -enemyScale[0];
                    enemyTarget.localScale = enemyScale;
                }
            }

        }*/
        
        //rb2D.AddForce(enemyForce);
        velocity.x = enemyForce.x;
        rb2D.velocity = velocity;
        //Vector2.MoveTowards(rb2D.position, direction, enemyMvmtSpeed * Time.fixedDeltaTime);

        float pathDistance = Vector2.Distance(rb2D.position, path.vectorPath[currWayPoint]);   //gets the path distance 

        if(pathDistance < nxtWayPoint)
        {
            currWayPoint++;
        }


        
    }
}
