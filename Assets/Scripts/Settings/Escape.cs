using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public Options myOptions;
    public PlayerMovement playerMovement;
    public RopeSystem ropeSystem;
    public PlayerInteracting playerInteracting;
    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (!myOptions.gameObject.activeSelf)
            {
                OpenOptions(); 
            }
            else
            {
                CloseOptions();
            }
        }
    }

    public void OpenOptions()
    {
        myOptions.gameObject.SetActive(true);
        playerMovement.enabled = false;
        ropeSystem.enabled = false;
        playerInteracting.enabled = false;
        Cursor.visible = true;
    }

    public void CloseOptions()
    {
        myOptions.gameObject.SetActive(false);
        playerMovement.enabled = true;
        ropeSystem.enabled = true;
        playerInteracting.enabled = true;
        Cursor.visible = false;
    }
}
