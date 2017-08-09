using UnityEngine;
using System.Collections;

public class muniçao : MonoBehaviour {


	int vel = 150;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0,vel * Time.deltaTime,0);

	}
}
