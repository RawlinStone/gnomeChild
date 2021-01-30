using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : MonoBehaviour
{
    public PlayerMovement groundedPlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //temp still deciding on implementation
        groundedPlayer.isGrounded = true; 
    }
}
