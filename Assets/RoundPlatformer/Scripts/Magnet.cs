using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public GameObject SparePartDetector;
    public float AttractionDuration = 6f;

    // Start is called before the first frame update
    void Start()
    {
        SparePartDetector = GameObject.FindGameObjectWithTag("SparePartDetector");
        SparePartDetector.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("ActivateAttraction");
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            
        }
    }

    IEnumerator ActivateAttraction()
    {
        SparePartDetector.SetActive(true);
        yield return new WaitForSeconds(AttractionDuration);
        SparePartDetector.SetActive(false);
        
        Destroy(gameObject);
    }
}

