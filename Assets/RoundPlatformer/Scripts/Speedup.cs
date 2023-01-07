using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedup : MonoBehaviour
{   

    public float SpeedCooldown;
	private float NormalSpeed;
	public float BoostedSpeed;

    private Player_Movement Player;

    // Start is called before the first frame update
    void Start()
    {   
        Player = GameObject.Find ("Player").GetComponent<Player_Movement>();    
        NormalSpeed = Player.PlayerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){

            Player.PlayerSpeed = BoostedSpeed;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            StartCoroutine("SpeedDuration");
        }
      

        
    }


	IEnumerator SpeedDuration () {
		yield return new WaitForSeconds(SpeedCooldown);
		Player.PlayerSpeed = NormalSpeed;
        Destroy(gameObject);
	}
}


