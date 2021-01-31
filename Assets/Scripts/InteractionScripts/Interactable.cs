using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private PlayerInteracting myPlayer;
    public Item myItem;
    public SpriteRenderer myRenderer;
    public Inventory playerInventory;
    public Sprite doorOpenSprite;
    public List<Sprite> bigDoorSprites;
    

    private void Start()
    {
        myPlayer = FindObjectOfType<PlayerInteracting>();
        myRenderer.sprite = myItem.sprite;
        if(myItem.type == "GEM")
        {
            if (playerInventory.GetGems().Contains(myItem))
            {
                Destroy(this.gameObject);
            }
        }
        else if(myItem.type == "KEY")
        {
            if (playerInventory.GetKeys().Contains(myItem))
            {
                Destroy(this.gameObject);
            }
        }
        else if (myItem.type == "DOOR")
        {
            if (myItem.isOpen)
            {
                OpenDoor();
            }
        }
        else if(myItem.type == "BIG")
        {
            if (myItem.isOpen)
            {
                OpenDoor();
            }
            else
            {
                UpdateBigDoor();
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myPlayer.canInteract = true;
            myPlayer.currentInteractable = myItem;
            myPlayer.overworldObject = this.gameObject;
            if (!myItem.isOpen)
            {
                myPlayer.DisplayInteraction();
            }
            
            
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

    public void UpdateBigDoor()
    {
        myRenderer.sprite = bigDoorSprites[myItem.gemsBig.Count];
    }

    public void OpenDoor()
    {
        myRenderer.sprite = doorOpenSprite;
    }
}
