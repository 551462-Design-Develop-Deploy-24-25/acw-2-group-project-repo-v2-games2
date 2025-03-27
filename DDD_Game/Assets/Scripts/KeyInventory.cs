using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{

    [SerializeField] 
    public bool hasKey;
    public bool hasRedKey;
    public bool hasOrangeKey;
    public bool hasPurpleKey;
    public bool hasYellowKey;

    public void KeyCollected(string keyName)
    {
        switch (keyName)
        {
            case "Key":
                hasKey = true;
                break;
            case "PurpleKey":
                hasPurpleKey = true;
                break;
            case "RedKey":
                hasRedKey = true;
                break;
            case "OrangeKey":
                hasOrangeKey = true;
                break;
        }
    }
}
