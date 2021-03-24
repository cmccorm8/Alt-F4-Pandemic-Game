using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    Flip flip;
    private Rigidbody2D rb2D;
    private Animator animator;
    public float npcMvmtSpeed = 5;
    //private Vector2 velocity;
    //private Vector2 npcForce;
    private Vector3 npcScale;
    private Vector3 rayCastTarget;
    public Transform rayCastPos;
    public Transform npcTransform;
    public float rayCastDistance;
    public float timeInterval = 8.0f;
    public LayerMask ground;
    private bool npcFlipped = false;
    private bool npcCanWalk = true;


    // Start is called before the first frame update
    void Start()
    {
       rb2D = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       StartCoroutine(RandomAI());
       
    }

    // Update is called once per frame
   
    private void FixedUpdate() 
    {
        //for the npc movement
        if(npcCanWalk)
        {
            NpcWalk();
        }
        else
        {
            NpcStop();
        }
        
        //npcScale used to flip sprite in Flip() function
        npcScale = npcTransform.localScale;
        
        //Determines if Flip() should be called
        if(IsObstructed() || IsAtEdge())
        {
            //print("Hitting Wall");
            Flip();
        }
        

        
    }

    /**
    * Function us to provide velocity to a NPC
    */
    void NpcWalk()
    {
        if(!npcFlipped)
        {
            rb2D.velocity = new Vector2(npcMvmtSpeed, rb2D.velocity.y);
        }
        else
        {
            float flippedVelocity = -npcMvmtSpeed;
            rb2D.velocity = new Vector2(flippedVelocity, rb2D.velocity.y);
        }
        

    }

    /**
    * Function to stop velocity on a NPC
    */
    void NpcStop()
    {
        rb2D.velocity = new Vector2(0,0);
    }

    /**
    * Function that flips the NPC Sprite depending on the direction traveling
    */
    void Flip()
    {
        if(npcFlipped)
        {
            npcTransform.Rotate(0f, 180f, 0f);
            npcFlipped = false;
        }
        else if(!npcFlipped)
        {
            npcTransform.Rotate(0f, 180f, 0f);
            npcFlipped = true;
            rb2D.velocity = new Vector2(npcMvmtSpeed,rb2D.velocity.y);  
            rayCastTarget.x += rayCastDistance;
            Debug.DrawLine(rayCastPos.position, rayCastTarget, Color.red);
        }

    }

    /**
    * Function that endlessly calls RandomAIRoutine and then waits a certian time interval
    */
    IEnumerator RandomAI()
    {
        while(true) 
        {
            RandomAIRoutine();
            //yield return new WaitForSeconds(Random.Range(10.0f, 20.0f));
            yield return new WaitForSecondsRealtime(timeInterval);

        }
        
    }

    /**
    * Function that randomly selects which routine a NPC should follow
    */
    void RandomAIRoutine()
    {
        float randomNum = Random.Range(0.0f, 1.0f);
        if(randomNum < 0.33f)
        {
            // the npc will stop
            npcCanWalk = false;
            print("RandomAI: made it < .33f");
        }
        else if(randomNum > 0.33f && randomNum < 0.66f)
        {
           // the npc can walk
           npcCanWalk = true;
            print("RandomAI: made it > .33f && < .66f");

        }
        else if(randomNum > 0.66f)
        {
            // the npc will flip directions
            Flip();
            print("RandomAI: made it > .66f");
        }

    }

    /**
    * Function that determines if an NPC has encountered an obstacle
    * If true then NPC will flip
    */
    bool IsObstructed()
    {
        bool obstructed = false;

        // determines and sets the raycast target position
        rayCastTarget = rayCastPos.position;
        rayCastTarget.x += rayCastDistance;

        //Debug.DrawLine(rayCastPos.position, rayCastTarget, Color.red);

        if(Physics2D.Linecast(rayCastPos.position, rayCastTarget, ground))
        {
            obstructed = true;
        }


        return obstructed;
    }

    /**
    * Function that determines if an NPC has encountered an edge
    * If true then NPC will flip
    */
    bool IsAtEdge()
    {
        bool atEdge = false;

        // determines and sets the raycast target position
        Vector3 rayCastTarget = rayCastPos.position;
        rayCastTarget.y -= rayCastDistance;

        //Debug.DrawLine(rayCastPos.position, rayCastTarget, Color.white);

        if(Physics2D.Linecast(rayCastPos.position, rayCastTarget, ground))
        {
            atEdge = false;
            //print("hitting ground");
        }
        else
        {
            atEdge = true;
        }


        return atEdge;
    }

    
}
