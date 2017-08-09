using UnityEngine;
using System.Collections;

public class tiro : MonoBehaviour {
	public Rigidbody rb;
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
		//rb.AddForce (transform.forward*150,ForceMode.Impulse);

	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		ContactPoint contact = collision.contacts [0];
		Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		GameObject obj = Instantiate (explosionPrefab, pos, rot) as GameObject;
		obj.GetComponentsInChildren<ParticleSystem> () [0].Play ();


		Destroy (gameObject);

		if (collision.gameObject.tag == "Inimigo") {
			PLAYER.inimigos_mortos += 1;
			Arma.cont += 1;
			SpawiInimigo.intervalo2--;
			Destroy (collision.gameObject);
		}

		
	}
}