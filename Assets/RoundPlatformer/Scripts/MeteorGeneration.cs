using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGeneration : MonoBehaviour
{   
    public GameObject[] MeteorPrefabs;
    public float MinMeteorSize;
    public float MaxMeteorSize;
    public GameObject GravityCenter;
    public float SpawningDistanceToCenter;
    public int SpawningRange;
    public float MeteorSpawnInterval;
    public int MaxMeteorAmount;
    private float MeteorStartingDistance;
    private List<GameObject> Meteors;
    private float LastSpawn;
    private float MeteorSize;
    private Vector3 MeteorPosition;
    

    // Start is called before the first frame update
    void Start()
    {   
        MinMeteorSize = 0.5f;
        // MaxMeteorSize = 4.0f; 
        Meteors = new List<GameObject>();
        LastSpawn = Time.time - MeteorSpawnInterval; // immediatley spawn first meteor
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastSpawn >= MeteorSpawnInterval)
        {      
            LastSpawn = Time.time;
            MeteorSize = Random.Range(MinMeteorSize, MaxMeteorSize);

            // spawn a meteor at a random position with some distance to the center
            do
            {
                int meteorX = Random.Range(-SpawningRange, SpawningRange);
                int meteorY = Random.Range(-SpawningRange, SpawningRange);

                MeteorPosition = new Vector3(meteorX, meteorY);
                
            } while (Vector3.Distance(MeteorPosition, GravityCenter.transform.position) <= SpawningDistanceToCenter);

            GenerateMeteor(MeteorSize, MeteorPosition);       
        }
    }

    //destroy a meteor if it hits the center
    void OnTriggerEnter2D(Collider2D collider)
    {   
        if (collider.CompareTag("Meteor"))
        {
            Meteors.Remove(collider.gameObject);
            Destroy(collider.gameObject);
        }
    }
   
    // creates a new meteor GameObject 
    private void GenerateMeteor(float size, Vector3 position)
    {   
        if (Meteors.Count < MaxMeteorAmount)
        {
            GameObject newMeteor = Instantiate(MeteorPrefabs[Random.Range(0,MeteorPrefabs.Length)], position, Quaternion.identity);
            newMeteor.transform.localScale = new Vector3(size,size,size);
            Meteors.Add(newMeteor);
        }
    }

}
