using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winInventory : MonoBehaviour
{   
    public List<GameObject> itemsToCollect;
    public List<GameObject> collectedItems;

    private void Start()
    {
        foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Item"))
        {
            itemsToCollect.Add(gameObject);
        }
        collectedItems = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        if(collectedItems.Count == itemsToCollect.Count)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Win Menu");
        }

    }
    public void CollectItem(GameObject item)
    {
        for (int i = 0; i < itemsToCollect.Count; i++)
        {
            if (itemsToCollect.Contains(item))
            {
                collectedItems.Add(item);
                itemsToCollect[i].SetActive(false);
                break;
            }
        }
    }
}

