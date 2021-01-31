using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Inventory inventory;
    public void Resume()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    public void StartGame()
    {
        inventory.ClearInventory(); 
        SceneManager.LoadScene("_mainHub"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
