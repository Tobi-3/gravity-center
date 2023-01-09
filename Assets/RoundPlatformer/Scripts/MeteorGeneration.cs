using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGeneration : MonoBehaviour
{   
    public GameObject MeteorPrefab;
    public GameObject GravityCenter;
    public float SpawningDistanceToCenter;
    public int SpawningRange;
    public float meteorSpawnInterval;
    public int maxMeteorAmount;
    private float meteorStartingDistance;
    private List<GameObject> meteors;
    private float lastSpawn;
    private float minMeteorSize;
    private float maxMeteorSize;
    private float meteorSize;
    private Vector3 meteorPosition;
    

    // Start is called before the first frame update
    void Start()
    {   
        minMeteorSize = 0.5f;
        maxMeteorSize = 4.0f; 
        meteors = new List<GameObject>();
        lastSpawn = Time.time - meteorSpawnInterval; // immediatley spawn first meteor
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawn >= meteorSpawnInterval)
        {      
            lastSpawn = Time.time;
            meteorSize = Random.Range(minMeteorSize, maxMeteorSize);

            // spawn a meteor at a random position with some distance to the center
            do
            {
                int meteorX = Random.Range(-SpawningRange, SpawningRange);
                int meteorY = Random.Range(-SpawningRange, SpawningRange);

                meteorPosition = new Vector3(meteorX, meteorY);
                
            } while (Vector3.Distance(meteorPosition, GravityCenter.transform.position) <= SpawningDistanceToCenter);

            GenerateMeteor(meteorSize, meteorPosition);       
        }
    }

    //destroy a meteor if it hits the center
    void OnTriggerEnter2D(Collider2D collider)
    {   
        if (collider.CompareTag("Meteor"))
        {
            meteors.Remove(collider.gameObject);
            Destroy(collider.gameObject);
        }
    }
   
    // creates a new meteor GameObject 
    private void GenerateMeteor(float size, Vector3 position)
    {   
        if (meteors.Count < maxMeteorAmount)
        {
            GameObject newMeteor = Instantiate(MeteorPrefab, position, Quaternion.identity);
            newMeteor.transform.localScale = new Vector3(size,size,size);
            meteors.Add(newMeteor);
        }
    }

}
