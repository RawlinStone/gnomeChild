using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public List<Item> inventory;

    public void AddItem(Item i)
    {
        inventory.Add(i);
    }

    public void DeleteItem(Item i)
    {
        inventory.Remove(i);
    }

    public void ClearInventory()
    {
        inventory.Clear();
    }
}
