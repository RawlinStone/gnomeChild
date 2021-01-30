using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float currentSpeed;
    public float crouchSpeed;
    public float jumpForce;
    public bool isGrounded = true;
    public Animator myAnimator;
    public SpriteRenderer myRenderer;
    public BoxCollider2D myCollider;
    private Rigidbody2D rb;
    [SerializeField]
    private bool crouch;
    [SerializeField]
    private bool jump;



    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    private void Update()
    {
        OnMove();
        CheckLanding();
        OnJump();
        OnCrouch();
        CheckCrouching(crouch);
       
        
    }

    private void OnMove()
    {
        float movement = Input.GetAxis("Horizontal");
        if(movement > 0)
        {
            myRenderer.flipX = false; 
        }
        else if(movement < 0)
        {
            myRenderer.flipX = true;
        }

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * currentSpeed;
        myAnimator.SetFloat("speed", Mathf.Abs(movement));
        myAnimator.SetBool("isCrouching", crouch); 

    }

    private void OnJump()
    {
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector3(0, jumpForce), ForceMode2D.Impulse);
            jump = true;
            myAnimator.SetBool("isJumping", true); 
        }
        
    }

    private void OnCrouch()
    {
        if(Input.GetButtonDown("Crouch") && !jump)
        {
            crouch = true;
            myCollider.offset = new Vector2(myCollider.offset.x,-0.0158636f);
            myCollider.size = new Vector2(myCollider.size.x, 0.2660642f);

        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
           myCollider.offset = new Vector2(myCollider.offset.x, -0.001397848f);
            myCollider.size = new Vector2(myCollider.size.x, 0.2783778f);

        }
    }

    
    private void CheckCrouching(bool c)
    {
        myAnimator.SetBool("isCrouching", c);
        if (c)
        {
            currentSpeed = crouchSpeed;
        }
        else
        {
            currentSpeed = speed;
            
        }
    }
   

    private void CheckLanding()
    {
         if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            jump = false;
            myAnimator.SetBool("isJumping", false);
        }

    }



}
