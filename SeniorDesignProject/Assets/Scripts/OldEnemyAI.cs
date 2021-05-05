using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ModifiedEnemyAI : MonoBehaviour
{
    public Transform enemyTarget;
    private float enemyMvmtSpeed = 400f;
    private float enemyMvmt = 0;
    private float nxtWayPoint = 3f;
    public Path path;
    int currWayPoint = 0;
    bool endOfPath = false;
    private Seeker harryPotter;
    protected Rigidbody2D rb2D;
    protected Vector2 direction;
    protected Vector2 enemyForce;
    protected Vector2 velocity;
    private Animator animator;
    private bool canSeePlayer = false;
    private bool playerLost = false;
    public bool enemyGrounded = false;
    public float timeInterval = 8.0f;

    // Start is called before the first frame update
    public void Start()
    {
        harryPotter = GetComponent<Seeker>();   //Gets a A* seeker component
        rb2D = GetComponent<Rigidbody2D>();     //Gets a rigidbody2d component

        InvokeRepeating("PathUpdate", 0f, .5f); // continuously updates the path

        harryPotter.StartPath(rb2D.position, enemyTarget.position, PathComplete);

        animator = GetComponent<Animator>();

        velocity = rb2D.velocity;
    }

    void PathUpdate()       //Invoked by InvokeRepeating to test if pathfinding is complete. if not updates the path
    {
        if (harryPotter.IsDone())
        {
            harryPotter.StartPath(rb2D.position, enemyTarget.position, PathComplete);
        }
    }

    void PathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currWayPoint = 0;
        }
    }

    private void AnimationHandler()
    {
        float temp = velocity.x * ((velocity.x < 0) ? -1 : 1);

        /*GB: Hopefully, this is no longer needed.
        //GB: Ignore random dips in velocity caused by the pathing algorithm.
        //    These dips are usually around 1.0E-05 or 1.0E-06
        if (temp > 1.0E-04) animator.SetFloat("Speed", temp);
        */

        animator.SetFloat("Speed", temp);
    }

    private void enemyPursuit()
    {
        direction = ((Vector2)path.vectorPath[currWayPoint] - rb2D.position).normalized;
        enemyForce = direction * enemyMvmtSpeed * Time.deltaTime;       //for enemy horizontal movement
        velocity = rb2D.velocity;
        velocity.x = enemyForce.x;
        rb2D.velocity = velocity;
    }

    /*IEnumerator enemyStop()
    {
        yield return new WaitForSecondsRealtime(timeInterval);
        canSeePlayer = false;
        print("enemy has stopped");
        
        
        enemyForce = direction * 0;       //for enemy horizontal movement
        
        velocity.x = 0;
    }*/


    private void enemyStop()
    {
        //yield return new WaitForSecondsRealtime(timeInterval);
        canSeePlayer = false;
        playerLost = false;
        print("enemy has stopped");

        enemyForce = direction * 0;       //for enemy horizontal movement

        velocity.x = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (path == null) // if no path return null
        {
            return;
        }

        if (currWayPoint >= path.vectorPath.Count) // check if currWayPoint is at the end of calculated path
        {
            endOfPath = true;
            return;
        }
        else
        {
            endOfPath = false;              //have not reached end of path
        }

        //if (canSeePlayer) enemyPursuit();


        if (playerLost)
        {
            enemyStop();
        }
        if (canSeePlayer)
        {
            enemyPursuit();
        }

        AnimationHandler();

        float pathDistance = Vector2.Distance(rb2D.position, path.vectorPath[currWayPoint]);   //gets the path distance 

        if (pathDistance < nxtWayPoint)
        {
            currWayPoint++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground" || collision.tag == "Obstacle")
        {
            enemyGrounded = true;
            print("Enemy is Grounded");

        }
        else if (collision.tag == "Player")
        {
            canSeePlayer = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground" || collision.tag == "Obstacle")
        {
            enemyGrounded = false;
        }
        else if (collision.tag == "Player")
        {
            playerLost = true;
            //StartCoroutine(enemyStop());
        }

    }
}
