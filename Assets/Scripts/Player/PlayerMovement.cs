using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isGrounded = true;
    public Animator myAnimator;
    public SpriteRenderer myRenderer;
    private Rigidbody2D rb;
    

    void Start() => rb = this.gameObject.GetComponent<Rigidbody2D>();

    private void Update()
    {
        OnMove();
        OnJump(); 
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

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        myAnimator.SetFloat("speed", Mathf.Abs(movement)); 

    }

    private void OnJump()
    {
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector3(0, jumpForce), ForceMode2D.Impulse);
        }
        
    }



}
