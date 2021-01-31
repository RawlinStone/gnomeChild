using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = respawnPoint.position;
    }
}
