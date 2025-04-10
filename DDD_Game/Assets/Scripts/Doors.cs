using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool isOpen { get; set; }
    public bool isLocked { get; set; }
    public GameObject Key;
    public Vector3 openPosition;
    public Vector3 openRotation;

    public async void MonsterDoor()
    {

        if (!isOpen)
        {
            transform.localPosition = openPosition;
            transform.localRotation = Quaternion.Euler(openRotation);
            isOpen = true;
            Coroutine coroutine = StartCoroutine("wait");
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        isOpen = false;
    }
    public void ToggleDoor(List<GameObject> keys = null)
    {
        if (Key != null)
        {
            if (keys.Contains(Key))
            {
                if (isOpen)
                {
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.identity;
                    isOpen = false;
                }
                else
                {
                    transform.localPosition = openPosition;
                    transform.localRotation = Quaternion.Euler(openRotation);
                    isOpen = true;
                }
            }
        }
        else
        {
            if (isOpen)
            {
                transform.position = Vector3.zero;
                transform.rotation = Quaternion.identity;
                isOpen = false;
            }
            else
            {
                //transform.position = openPosition;
                //transform.rotation = Quaternion.Euler(openRotation);
                isOpen = true;
            }
        }


    }
}
