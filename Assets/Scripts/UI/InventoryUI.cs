using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //0:Ruby, 1:Sapphire, 2:Emerald
    public List<Image> myGemsUI;


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
        }
    }

}
