using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private PlayerInteracting myPlayer;
    public Item myItem;
    public SpriteRenderer myRenderer;
    

    private void Start()
    {
        myPlayer = FindObjectOfType<PlayerInteracting>();
        myRenderer.sprite = myItem.sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myPlayer.canInteract = true;
            myPlayer.currentInteractable = myItem;
            myPlayer.DisplayInteraction();
            myPlayer.overworldObject = this.gameObject;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myPlayer.canInteract = false;
            myPlayer.currentInteractable = null;
            myPlayer.HideInteraction();
            myPlayer.overworldObject = null;
        }
    }
}
