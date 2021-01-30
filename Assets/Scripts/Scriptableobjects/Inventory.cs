using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public List<Item> keys;
    public List<Item> gems;

    public void AddItem(Item i)
    {
        if(i.type == "GEM")
        {
            gems.Add(i);
        }
        else if(i.type == "KEY")
        {
            keys.Add(i);
        }
        
    }

    public void DeleteItem(Item i)
    {
        if (i.type == "GEM")
        {
            gems.Remove(i);
        }
        else if (i.type == "KEY")
        {
            keys.Remove(i);
        }
    }

    public void ClearInventory()
    {
        keys.Clear();
        gems.Clear();
    }

    public List<Item> GetGems()
    {
        return gems;
    }

    public List<Item> GetKeys()
    {
        return keys;
    }
}
