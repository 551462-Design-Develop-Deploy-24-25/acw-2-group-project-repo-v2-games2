using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winInventory : MonoBehaviour
{
    GameObject[] itemsToCollect;
    GameObject[] collectedItems;

    private void Start()
    {
        itemsToCollect = GameObject.FindGameObjectsWithTag("Item");
        collectedItems = new GameObject[itemsToCollect.Length];
    }
    public void CollectItem(GameObject item)
    {
        for (int i = 0; i < itemsToCollect.Length; i++)
        {
            if (itemsToCollect[i] == item)
            {
                collectedItems[i] = item;
                itemsToCollect[i].SetActive(false);
                break;
            }
        }
    }
}

