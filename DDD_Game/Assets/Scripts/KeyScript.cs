using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        KeyInventory keyInventory = other.GetComponent<KeyInventory>();

        if (keyInventory != null)
        {
            keyInventory.KeyCollected();
            gameObject.SetActive(false);
        }
    }
}
