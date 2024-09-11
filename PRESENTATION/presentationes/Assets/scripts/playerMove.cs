using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    //Defines user Inputs
    
    public KeyCode jump;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    //Defines variables used 

    public float buildUp;
    public float maxSpeed;
    public float jumpForce;
    public float stompForce;
    
    public bool isAirborne;
    private Vector2 moveInput;
    private Rigidbody2D rb2d;


    //LEARN RAYCASTING & STUFF FOR STICKINESS

    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the character Up (Jump)

        if (Input.GetKeyDown(jump) && !isAirborne)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isAirborne = true;
        }
        
      
        //Moves character down (Fastfall)
        if (Input.GetKeyDown(down) && isAirborne)
        {
            rb2d.AddForce(Vector2.down * stompForce);
        }

    }
    private void FixedUpdate()
    {
        //Moves the character left and right

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.Normalize();
        rb2d.AddForce(moveInput * buildUp); 

        

        //Caps speed using the maxSpeed and maxSpeed variable
        //rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);

    }




    
    private void OnCollisionStay2D(Collision2D other)
    {

        //if player is touching the ground 
        if (other.gameObject.CompareTag("ground"))
        {
            //other.contacts[0]
            isAirborne = false;
        }
        

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isAirborne = true;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            print("In");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            print("Out");
        }
    }
}
