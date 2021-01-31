using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //0:Ruby, 1:Sapphire, 2:Emerald, 3:Amethyst
    public List<Image> myGemsUI;
    public List<Image> myKeysUI;


    public void UpdateGems(List<Item> myGems)
    {
        foreach(Item gem in myGems)
        {
            if(gem.name == "Ruby")
            {
                myGemsUI[0].gameObject.SetActive(true);
            }
            if(gem.name == "Sapphire")
            {
                myGemsUI[1].gameObject.SetActive(true);
            }
            if(gem.name == "Emerald")
            {
                myGemsUI[2].gameObject.SetActive(true);
            }
            if(gem.name == "Amethyst")
            {
                myGemsUI[3].gameObject.SetActive(true);
            }
        }
    }

    public void UpdateKeys(List<Item> myKeys)
    {
        foreach(Item key in myKeys)
        {
            if (key.color == "RED")
            {
                myKeysUI[0].gameObject.SetActive(true);
            }
            if (key.color == "BLUE")
            {
                myKeysUI[1].gameObject.SetActive(true);
            }
            if (key.color == "GREEN")
            {
                myKeysUI[2].gameObject.SetActive(true);
            }
            if (key.color == "PURPLE")
            {
                myKeysUI[3].gameObject.SetActive(true);
            }
        }
    }

}
