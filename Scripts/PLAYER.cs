using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
[RequireComponent(typeof (AudioSource))]
public class PLAYER : MonoBehaviour {
	[SerializeField] public static float VIDA;
	[SerializeField] private AudioClip m_dano;           // the sound played when character touches back on ground.

	public static int balas;


	public static int inimigos_mortos;
	public GameObject score_text;

	public GameObject life_text;
	public GameObject mun_text;

	private float cronometroDano;
	public float tempoDano;
	public Texture Dano;
	public bool ativarDano;
	private AudioSource m_AudioSource;

	void Start(){
		VIDA = 50;
		balas = 20;
		inimigos_mortos = 0;
		Cursor.visible = false;
		life_text = GameObject.FindGameObjectWithTag ("life_text");
		mun_text = GameObject.FindGameObjectWithTag ("mun_text");
		score_text = GameObject.FindGameObjectWithTag ("score_text");
		m_AudioSource = GetComponent<AudioSource>();

	}

	private void PlaySound()
	{
		m_AudioSource.clip = m_dano;
		m_AudioSource.Play();

	}

	void Update(){
		
		life_text.GetComponent<TextMesh> ().text = ""+VIDA;
		mun_text.GetComponent<TextMesh> ().text = ""+balas;
		score_text.GetComponent<TextMesh> ().text = ""+inimigos_mortos;

		if (Input.GetKeyDown (KeyCode.Escape)) {
			gameObject.SetActive(true);
			SceneManager.LoadScene ("Menu");
			Cursor.visible = true;
		}

		if (balas <= 0) {

			balas = 0;
		}

		if (VIDA <= 0) {
			SceneManager.LoadScene ("Game_Over");
		}

		if (ativarDano == true) {
			cronometroDano += Time.deltaTime;
		}
		if (cronometroDano >= tempoDano) {
			ativarDano = false;
			cronometroDano = 0;
		}

	}


	void OnCollisionEnter (Collision collision){
		if (collision.transform.tag == "Inimigo") {
			VIDA -= 10;
			PlaySound ();
			ativarDano = true;
		}
		if (collision.transform.tag == "municao") {
			balas += 10;
		
			Destroy (collision.gameObject);
		}
	}

	void OnGUI () {
		if (ativarDano == true)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Dano);
	}

}