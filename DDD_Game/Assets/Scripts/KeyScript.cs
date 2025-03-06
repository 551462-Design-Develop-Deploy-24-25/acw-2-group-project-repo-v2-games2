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
            Debug.Log(this.gameObject.name);
            keyInventory.KeyCollected(this.gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
