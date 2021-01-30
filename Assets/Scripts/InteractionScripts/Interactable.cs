using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private PlayerInteracting myPlayer;
    public Item myItem;

    private void Start()
    {
        myPlayer = FindObjectOfType<PlayerInteracting>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myPlayer.canInteract = true;
            myPlayer.currentInteractable = myItem;
            myPlayer.DisplayInteraction();
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myPlayer.canInteract = false;
            myPlayer.currentInteractable = null;
            myPlayer.HideInteraction();
        }
    }
}
