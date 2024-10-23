using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public float jumpPower;
    private float horizontal;
    public LayerMask floor;
    public Transform groundcheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower * 0.5f);
        }
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 2f, floor);
    }
}
