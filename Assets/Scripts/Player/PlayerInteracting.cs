using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracting : MonoBehaviour
{
    public bool canInteract;
    public GameObject myThinkingBubble;
    public SpriteRenderer currentSprite;
    public Item currentInteractable;



    private void Update()
    {
        OnInteract();
    }

    private void OnInteract()
    {
        if(Input.GetButtonDown("Interact") && canInteract)
        {
            Debug.Log("We have interaction");
        }
    }

    public void DisplayInteraction()
    {
        myThinkingBubble.SetActive(true);
        currentSprite.sprite = currentInteractable.sprite;
    }

    public void HideInteraction()
    {
        myThinkingBubble.SetActive(false);
        currentSprite.sprite = null;
    }

    private void ClearInteractable()
    {
        currentInteractable = null;
    }
}
