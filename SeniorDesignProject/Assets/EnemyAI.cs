using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform enemyTarget;
    public float enemyMvmtSpeed = 200f;
    public float enemyMvmt = 0;
    public float nxtWayPoint = 3f;
    public Path path;
    int currWayPoint = 0;
    bool endOfPath = false;
    public Seeker harryPotter;
    protected Rigidbody2D rb2D;
    public Vector2 direction;
    public Vector2 enemyForce;
    public Vector2 velocity;
    private Animator animator;

    // Start is called before the first frame update
    public void Start()
    {
        harryPotter = GetComponent<Seeker>();   //Gets a A* seeker component
        rb2D = GetComponent<Rigidbody2D>();     //Gets a rigidbody2d component

        InvokeRepeating("PathUpdate", 0f, .5f); // continuously updates the path

        harryPotter.StartPath(rb2D.position, enemyTarget.position, PathComplete);

        animator = GetComponent<Animator>();
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

    private void AnimationHandler()
    {
        float temp = velocity.x * ((velocity.x < 0) ? -1 : 1);

        //GB: Ignore random dips in velocity caused by the pathing algorithm.
        //    These dips are usually around 1.0E-05 or 1.0E-06
        if (temp > 1.0E-04) animator.SetFloat("Speed", temp);

    }

    // Update is called once per frame
    private void FixedUpdate()
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

        direction =((Vector2)path.vectorPath[currWayPoint] - rb2D.position).normalized;
        enemyForce = direction * enemyMvmtSpeed * Time.deltaTime;       //for enemy horizontal movement
        velocity = rb2D.velocity;

        
        //rb2D.AddForce(enemyForce);
        velocity.x = enemyForce.x;
        rb2D.velocity = velocity;
        //Vector2.MoveTowards(rb2D.position, direction, enemyMvmtSpeed * Time.fixedDeltaTime);

        AnimationHandler();

        float pathDistance = Vector2.Distance(rb2D.position, path.vectorPath[currWayPoint]);   //gets the path distance 

        if(pathDistance < nxtWayPoint)
        {
            currWayPoint++;
        }


        
    }
}
