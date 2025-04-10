using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public List<GameObject> keys = new List<GameObject>();


    public void addKey(GameObject key)
    {
        keys.Add(key);
    }

    public List<GameObject> getKeys()
    {
        return keys;
    }
    public bool getKey(GameObject key)
    {
        if (keys.Contains(key))
        {
            return true;
        }
        return false;
    }
}
