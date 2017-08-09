using UnityEngine;
using System.Collections;

public class SpawiInimigo : MonoBehaviour {

	public GameObject inimigo;
	public int intervalo;
	public static int intervalo2;

	// Use this for initialization
	void Start () {
		intervalo2 = 30;
		InvokeRepeating ("SpawnInimigo", intervalo, intervalo2);
	}
	
	// Update is called once per frame
	void SpawnInimigo () {
		Instantiate (inimigo, gameObject.transform.position, gameObject.transform.rotation);
	}

}
