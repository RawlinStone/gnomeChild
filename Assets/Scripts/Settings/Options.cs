using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Inventory inventory;
    public GameObject creditsPage;
    public List<Item> myItems;
    

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    public void StartGame()
    {
        inventory.ClearInventory(); 
        foreach(Item i in myItems)
        {
            i.ResetDoors();
        }
        SceneManager.LoadScene("_mainHub"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void OpenCredits()
    {
        creditsPage.SetActive(true);
    }
    public void CloseCredits()
    {
        creditsPage.SetActive(false);
    }
}
