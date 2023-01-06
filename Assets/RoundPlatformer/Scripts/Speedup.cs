using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedup : MonoBehaviour
{   

    public float SpeedCooldown;
	private float NormalSpeed;
	public float BoostedSpeed;
    private float coeffSpeedUp = 1.0f;
    
    private Player_Movement Player;
    // float move = Input.GetAxis ("Horizontal") * coeffSpeedUp;

    // Start is called before the first frame update
    void Start()
    {   
        Player = GameObject.Find ("Player").GetComponent<Player_Movement>();    
        NormalSpeed = 5;
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
            
            
            // other.GetComponent<Player_Movement>().PlayerSpeed = 5;
        }
      

        
    }


	IEnumerator SpeedDuration () {
		yield return new WaitForSeconds(SpeedCooldown);
		Player.PlayerSpeed = 5;
        Destroy(gameObject);
	}
}


