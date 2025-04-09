using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeylessDoor : MonoBehaviour
{
    public bool isOpen { get; private set; }

    private void OnTriggerEnter(Collider other)
    {

        KeyInventory keyInventory = other.GetComponent<KeyInventory>();

        if (keyInventory != null && !isOpen)
        {
            transform.Translate(-1.5f, 0f, 1f);
            transform.Rotate(0f, 90f, 0f);
            isOpen = true;
        }
        else if (keyInventory != null)
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        this.GetComponent<BoxCollider>().isTrigger = true;
    }
}
