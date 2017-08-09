using UnityEngine;
using System.Collections;

public class morte : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Player") {
			PLAYER.VIDA = 0;
		}
		
}
}