using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{   
    [Header("Player References")]
    [SerializeField] private PlayerInventory _playerInventory;

    private GameObject ShieldObject;

    // Start is called before the first frame update
    void Start()
    {   
        ShieldObject = GameObject.FindWithTag("Shield");  
        
        // move shield to center of player character
        ShieldObject.transform.position = _playerInventory.gameObject.GetComponent<Collider2D>().bounds.center;
        
        //disable the shield if the power up hasn't been collected/wears off
        ShieldObject.GetComponent<SpriteRenderer>().enabled = false;
        ShieldObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            _playerInventory.powerUpPickedUp = true;
            Destroy(gameObject);
            ShieldObject.GetComponent<SpriteRenderer>().enabled = true;
            ShieldObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

	
}


