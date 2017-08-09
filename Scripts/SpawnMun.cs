using UnityEngine;
using System.Collections;

public class SpawnMun : MonoBehaviour {

	public GameObject caixa;
	public int intervalo;
	public int intervalo2;

	// Use this for initialization
	void Start () {
		intervalo = 10;
		intervalo2 = 100;;
		InvokeRepeating ("Spawnmun", intervalo, intervalo2);
	}

	// Update is called once per frame
	void Spawnmun () {
		Instantiate (caixa, gameObject.transform.position, gameObject.transform.rotation);
	}
}
