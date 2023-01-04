using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpareParts : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if(playerInventory != null)
        {
            playerInventory.PartsCollected();
            gameObject.SetActive(false);
        }
    }

}
