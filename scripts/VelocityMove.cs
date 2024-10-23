using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    

    public float buildUp;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moves the player
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.Normalize();
        rb2d.velocity = moveInput * buildUp;

        //clamps movement
        
            rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);
        
    }
}
