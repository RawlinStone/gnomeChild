using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    
    //gem or key
    public string type;
    public string color;
    public bool isOpen;
    public Item keyNeeded;
    public string levelName;
    public List<Item> gemsBig;

    public void ResetDoors()
    {
        if(color != "BROWN")
        {
            isOpen = false;
            gemsBig.Clear(); 
        }
    }

   
}
