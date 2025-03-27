using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleDoor : MonoBehaviour
{
    [SerializeField]
    public bool isOpen;

    private void OnTriggerEnter(Collider other)
    {

        KeyInventory keyInventory = other.GetComponent<KeyInventory>();

        if (keyInventory != null && keyInventory.hasPurpleKey == true && !isOpen)
        {
            this.transform.Translate(1.5f, 0f, 1f);
            this.transform.Rotate(0f, -90f, 0f);
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
