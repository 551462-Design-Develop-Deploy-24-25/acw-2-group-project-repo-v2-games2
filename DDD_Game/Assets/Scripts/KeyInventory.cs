using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public bool hasKey { get; private set; }
    public bool hasRedKey { get; private set; }
    public bool hasOrangeKey { get; private set; }
    public bool hasPurpleKey { get; private set; }
    public bool hasYellowKey { get; private set; }

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
