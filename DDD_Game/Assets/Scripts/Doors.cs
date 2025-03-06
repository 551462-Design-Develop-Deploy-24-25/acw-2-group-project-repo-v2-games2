using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        KeyInventory keyInventory = other.GetComponent<KeyInventory>();

        if (keyInventory != null && keyInventory.hasKey == true)
        {
            transform.Translate(-1.5f, 0f, 1f);
            transform.Rotate(0f, 90f, 0f);
        }
        else if (keyInventory != null)
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
