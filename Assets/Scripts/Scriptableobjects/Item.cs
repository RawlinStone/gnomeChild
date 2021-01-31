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

   
}
