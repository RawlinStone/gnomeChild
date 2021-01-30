using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracting : MonoBehaviour
{
    public bool canInteract;
    public GameObject myThinkingBubble;
    public SpriteRenderer currentSprite;
    public Item currentInteractable;
    public InventoryManager inventoryManager;
    public GameObject overworldObject;
    public InventoryUI myInventoryUI;

    void Start()
    {
        myInventoryUI.UpdateGems(inventoryManager.myInventory.GetGems());
        myInventoryUI.UpdateKeys(inventoryManager.myInventory.GetKeys());
    }

    private void Update()
    {
        OnInteract();
    }

    private void OnInteract()
    {
        if(Input.GetButtonDown("Interact") && canInteract)
        {
            inventoryManager.myInventory.AddItem(currentInteractable);
            if(currentInteractable.type == "GEM")
            {
                myInventoryUI.UpdateGems(inventoryManager.myInventory.GetGems());
            }
            else if(currentInteractable.type == "KEY")
            {
                myInventoryUI.UpdateKeys(inventoryManager.myInventory.GetKeys());
            }
            ClearInteractable();
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
        HideInteraction();
        Destroy(overworldObject);

    }
}
