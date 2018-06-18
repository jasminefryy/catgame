using System.Collections;
using UnityEngine;

public class Pickups : MonoBehaviour {

	Player player;
	public int points;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		
	}

	/*whatever object with a collider enters the trigger
	will be registered with the name 'hit'*/
	void OnTriggerEnter2D(Collider2D hit) { 
		if (hit.CompareTag ("Player")) {
			player.points += points;
			Destroy (gameObject);
		}
	}
}
