using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    private GameObject SparePartDetector;
    private GameObject SmallMagnet;
    public float AttractionDuration = 6f;

    // Start is called before the first frame update
    void Start()
    {
        SparePartDetector = GameObject.FindWithTag("SparePartDetector");
        SmallMagnet = GameObject.FindWithTag("Magnet");

        SparePartDetector.GetComponent<Collider2D>().enabled = false;
        
        SmallMagnet.GetComponent<SpriteRenderer>().enabled = false;

        // move SparePartDetector to center of player character
        SparePartDetector.transform.position = SparePartDetector.gameObject.GetComponent<Collider2D>().bounds.center;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("ActivateAttraction");

            // make magnet power up not interact with the player
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator ActivateAttraction()
    {
        SparePartDetector.GetComponent<Collider2D>().enabled = true;
        SmallMagnet.GetComponent<SpriteRenderer>().enabled = true;
        
        yield return new WaitForSeconds(AttractionDuration);

        SparePartDetector.GetComponent<Collider2D>().enabled = false;
        SmallMagnet.GetComponent<SpriteRenderer>().enabled = false;
        
        Destroy(gameObject);
    }
}

