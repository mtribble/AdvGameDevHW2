using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    string name, description;

    public InventoryItem(string newName)
    {
        name = newName;
        description = "";
    }
    public string GetName()
    {
        return name;
    }

}
