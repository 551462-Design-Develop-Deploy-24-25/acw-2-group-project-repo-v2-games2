using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KeylessDoor : MonoBehaviour
{
    [SerializeField] private float3 Translate;
    [SerializeField] private float3 Rotate;
    public bool isOpen { get; private set; }

    private void OnTriggerEnter(Collider other)
    {

        KeyInventory keyInventory = other.GetComponent<KeyInventory>();

        if (keyInventory != null && !isOpen)
        {
            transform.Translate(Translate.x, Translate.y, Translate.z);
            transform.Rotate(Rotate.x, Rotate.y, Rotate.z);
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
