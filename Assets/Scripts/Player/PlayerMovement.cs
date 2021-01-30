using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isGrounded = true;
    private Rigidbody2D rb;

    void Start() => rb = this.gameObject.GetComponent<Rigidbody2D>();

    private void Update()
    {
        OnMove();
        OnJump(); 
    }

    private void OnMove()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * speed; 
    }

    private void OnJump()
    {
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector3(0, jumpForce), ForceMode2D.Impulse);
        }
        
    }



}
