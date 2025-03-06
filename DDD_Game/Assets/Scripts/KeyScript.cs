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
            Debug.Log("this is the key talking");
            keyInventory.KeyCollected();
            gameObject.SetActive(false);
        }
    }
}
