using UnityEngine;
using System.Collections;

public class Arma : MonoBehaviour {
	
	public GameObject tiro;
	public static int cont = 0;
	public float timeBetweenShots = 1.5f;  // Allow 3 shots per second
	private float timestamp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (cont == 5) {

			PLAYER.balas += 5;
			cont = 0;
		}
	
		/*if (Time.time >= timestamp && (Input.GetKeyDown(KeyCode.Mouse0)) && PLAYER.balas > 0) {
			
			Instantiate (tiro, transform.position, transform.rotation); 
			timestamp = Time.time + timeBetweenShots;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play();
			PLAYER.balas -= 1;
		}

*/
	}

}


	