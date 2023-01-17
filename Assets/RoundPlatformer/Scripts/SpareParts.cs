using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpareParts : MonoBehaviour
{
    
     public Transform playerTransform;
    public float moveSpeed = 10f;

    SparePartMove sparePartMoveScript;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        sparePartMoveScript = gameObject.GetComponent<SparePartMove>();
        sparePartMoveScript.enabled =  false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if(playerInventory != null)
        {
            playerInventory.PartsCollected();
            gameObject.SetActive(false);
        }

        if (other.CompareTag("SparePartDetector"))
        {   
            sparePartMoveScript.enabled =  true;
        }
    }
}