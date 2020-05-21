using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == MainRunner.Instance.noteTag)
        {
            ItemBehaviour item = other.GetComponent<ItemBehaviour>();

            item.Interact();
        }
    }
}
