using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRefill : MonoBehaviour
{   

    private OxygenSystem Oxygen;
    public float ReplenishAmount;
    public bool refillig;

     void Start()
    {   
        Oxygen = GameObject.FindWithTag("Canvas").GetComponent<OxygenUISystem>().GetOxygenSystem();  
        if (Oxygen == null){
            Oxygen = GameObject.Find("Canvas").GetComponent<OxygenUISystem>().GetOxygenSystem();
        }
    }

    void Update(){
        refillig = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
           refillig = true;
           Oxygen.ReplenishOxygen(ReplenishAmount);
        }
    }
}


