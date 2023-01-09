using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRefill : MonoBehaviour
{   

    private OxygenSystem Oxygen;
    public float ReplenishAmount;

     void Start()
    {   
        Oxygen = GameObject.FindWithTag("Canvas").GetComponent<OxygenUISystem>().GetOxygenSystem();  
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
           Debug.Log("Triggering OnTriggerStay");
           Oxygen.ReplenishOxygen(ReplenishAmount);
        }
    }

	
}


