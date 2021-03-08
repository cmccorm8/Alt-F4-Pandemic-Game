using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class AdvanceEnemyAI : EnemyAI
{
    //public EnemyAI advancedEnemy = new EnemyAI();
    public bool enemyGrounded=false;
    public bool canJump = false;
    //public int enemyjumpCnt=0;
    public float jumpForce = 100f;
    //public float enemySpeed = 7f;
    public float jumpHeightTrigger = 0.5f;

    public Transform groundCheck;
    public float groundRadius;
    public LayerMask ground;
    
    
    // Start is called before the first frame update
    void Start()
    {
        base.Start(); //calls the Start function of the parent class
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        IsGrounded();
        
        if(canJump)
        {
            EnemyJump();
        }
    }

    
    private bool IsGrounded()
    {
        //float addHeight = .5f; //for any potential sloped ground
        //enemyGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius+addHeight, ground);    
        if(enemyGrounded == true) {
            //print("Enemy is grounded");
            canJump = true;   
        }
        else{
            canJump = false;
        }
        return canJump;
    }

    private void EnemyJump()
    {
        if(base.direction.y > jumpHeightTrigger)
        {
                
            base.rb2D.AddForce(Vector2.up * jumpForce);

        }

    }

    

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.tag == "Obstacle")
        {
            base.rb2D.AddForce(Vector2.up * 50f);
            base.rb2D.AddForce(base.enemyForce);
            //enemyjumpCnt++;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ground" || collision.tag == "Obstacle")
        {
            enemyGrounded = true;
            print("Enemy is Grounded");
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.tag == "ground" || collision.tag == "Obstacle")
        {
            enemyGrounded = false;
        }
        
    }
}
