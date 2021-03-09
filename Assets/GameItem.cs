using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    [SerializeField] string name = "Item";

    public string GetName()
    {
        return name;
    }
}
