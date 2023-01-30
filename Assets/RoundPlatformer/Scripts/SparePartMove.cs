using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparePartMove : MonoBehaviour
{

    SpareParts sparePartScript;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        sparePartScript = gameObject.GetComponent<SpareParts>();

        Player = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position,
            sparePartScript.moveSpeed * Time.deltaTime);
    }
}
