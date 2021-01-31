using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerInteracting : MonoBehaviour
{
    public bool canInteract;
    public GameObject myThinkingBubble;
    public SpriteRenderer currentSprite;
    public Item currentInteractable;
    public InventoryManager inventoryManager;
    public GameObject overworldObject;
    public InventoryUI myInventoryUI;
    public Sprite defaultKey;
    public List<Sprite> bigDoorSprites;
    //0:big door, 1:regualr door, 2:gem placement
    public List<AudioClip> audioClips;
    public AudioSource audioSource;
    

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
                
                ClearInteractable();
            }
            else if(currentInteractable.type == "KEY")
            {
                myInventoryUI.UpdateKeys(inventoryManager.myInventory.GetKeys());
                ClearInteractable();
            }
            else if(currentInteractable.type == "DOOR")
            {
                if (inventoryManager.myInventory.GetKeys().Contains(currentInteractable.keyNeeded) && !currentInteractable.isOpen)
                {
                    //open door
                    //PLAY SOUND
                    audioSource.clip = audioClips[1];
                    audioSource.Play();
                    currentInteractable.isOpen = true;
                    overworldObject.GetComponent<Interactable>().OpenDoor();
                    overworldObject.GetComponent<Interactable>().PlayParticle(); 
                    HideInteraction();

                }
                else if (currentInteractable.isOpen)
                {
                    SceneManager.LoadScene(currentInteractable.levelName); 
                }
            }
            else if(currentInteractable.type == "BIG")
            {
                if (!currentInteractable.isOpen)
                {
                    if(currentInteractable.gemsBig.Count >= 4)
                    {
                        currentInteractable.isOpen = true;
                        //PLAY SOUND
                        audioSource.clip = audioClips[0];
                        audioSource.Play();
                        overworldObject.GetComponent<Interactable>().OpenDoor();
                        overworldObject.GetComponent<Interactable>().PlayParticle();
                    }
                    else
                    {
                        foreach (Item i in inventoryManager.myInventory.GetGems())
                        {
                            if (!currentInteractable.gemsBig.Contains(i))
                            {
                                //PLAY SOUND
                                audioSource.clip = audioClips[2];
                                audioSource.Play();
                                currentInteractable.gemsBig.Add(i);
                            }
                        }
                        overworldObject.GetComponent<Interactable>().UpdateBigDoor();
                    }
                    
                }
                else
                {
                    //go to final place
                    SceneManager.LoadScene("EndScene");
                }
            }
            
        }
    }

    public void DisplayInteraction()
    {
        myThinkingBubble.SetActive(true);
        if(currentInteractable.type == "DOOR" && !currentInteractable.isOpen)
        {
            currentSprite.sprite = defaultKey;
        }
        else
        {
            currentSprite.sprite = currentInteractable.sprite;
        }
        
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
