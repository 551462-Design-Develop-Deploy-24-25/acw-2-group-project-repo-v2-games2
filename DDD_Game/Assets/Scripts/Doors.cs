using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    //default positions
    /*
     * 0, 2.25, 5
     * 0, 0, 0
     * 0.85, 5, 3
     */

    //opened positions
    /*
     * -1.5, 2.25, 6
     * 0, 90, 0
     * 0.85, 5, 3
     */
    private void OnTriggerEnter(Collider other)
    {

        KeyInventory keyInventory = other.GetComponent<KeyInventory>();

        if (keyInventory != null && keyInventory.hasKey == true)
        {
            Debug.Log("you have key i am door");
            transform.Translate(-1.5f, 0f, 1f);
            transform.Rotate(0f, 90f, 0f);
        }
        else if (keyInventory != null)
        {
            Debug.Log("collision detected but no key");
            this.GetComponent<BoxCollider>().isTrigger = false;
        }


        //transform.Translate(-1.5f, 0f, 1f);
        //transform.Rotate(0f, 90f, 0f);
        //this.GetComponent<BoxCollider>().isTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collision no longer detected");
        //transform.Translate(1.5f, 0f, -1f);
        //transform.Rotate(0f, -90f, 0f);
        this.GetComponent<BoxCollider>().isTrigger = false;
    }
}
