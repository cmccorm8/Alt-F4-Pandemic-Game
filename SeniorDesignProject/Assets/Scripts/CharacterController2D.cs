using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public Animator animator;
    public float mvmtSpeed = 7;
    public float pcMvmt = 0f;
    public float jumpForce = 400f;
    public float dblJumpForce = 5f;
    private Rigidbody2D rb2D;
    private int jumpCnt;
    private bool jump = false;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask ground;
    private bool grounded;
    private SpriteRenderer spriteRenderer;
    public InfectionMeter infection;
    public Transform playerTransform;

    private bool flipped = false;
    //public float infectionScore = 0;
    public int tpValue = 1;

    CharacterController2D controller;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>(); //gets a reference to a RigidBody2D object whenever a player is created

        //animator.GetComponent<Animator>(); //animator component

        spriteRenderer = GetComponent<SpriteRenderer>(); // used to flip sprite of main character

        /*Physics2D.IgnoreLayerCollision(8, 12);
        Physics2D.IgnoreLayerCollision(12, 12);*/

    }

    private void Flip()
    {
        Vector3 scale = playerTransform.localScale;

        if (pcMvmt < 0 && !flipped)
        {
            playerTransform.localScale = new Vector3((-1 * scale.x), scale.y, scale.z);
            flipped = true;
        }
        else if (pcMvmt > 0 && flipped)
        {
            playerTransform.localScale = new Vector3((-1 * scale.x), scale.y, scale.z);
            flipped = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //for the horizontal movement
        pcMvmt = Input.GetAxis("Horizontal");

        Flip();
        
        //print(pcMvmt);
        animator.SetFloat("Speed", Mathf.Abs(pcMvmt)); //if speed >.01(right) or <.01(left) on horizontal axis transition to run animation


        //for the jump
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            if (++jumpCnt < 2)
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                //jumpCnt++;
            }   
            
        }
        if(IsGrounded())
        {
            jumpCnt=0;
            
        }   
    }

    void FixedUpdate() {

        transform.position +=new Vector3(pcMvmt,0,0) * Time.deltaTime * mvmtSpeed; //for horizontal movement
        
        //IsGrounded();
        if(jump == true && jumpCnt == 0) 
        {
            rb2D.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
        }
        else if((jump == true && jumpCnt < 2))
        {
            
            rb2D.AddForce(new Vector2(0,dblJumpForce), ForceMode2D.Impulse);
            
        }
        jump = false;  
        
    }

    //IsGrounded() can be used to implement a potential double jump feature
    private bool IsGrounded()
    {
        float addHeight = .5f; //for any potential sloped ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius+addHeight, ground);
         
        
        if(grounded == true) {
            //print("Player is grounded");
            animator.SetBool("IsJumping", false);
            
        }
        else{
          animator.SetBool("IsJumping", true);  
        }
        return grounded;
    }

    int temp = 0;

    private void OnTriggerStay2D(Collider2D infected)
    {
        if (infected.tag == "Enemy")
        {
            temp++;
            infection.add(1);
            //infectionScore = Mathf.Floor(infectionScore);
            //print("Infection Score " + temp);
        }

        /*if (temp == 500)
        {
            FindObjectOfType<AudioManager>().StopPlaying("MainTheme");
            FindObjectOfType<AudioManager>().Play("Infected");
            FindObjectOfType<AudioManager>().Play("InfectedTheme");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectible")
        {
            print("TP collected");
            Destroy(collision.gameObject);
            ItemManager.itemManager.UpdateScore(tpValue);
            FindObjectOfType<AudioManager>().Play("PickupItem");
        }
    }
}