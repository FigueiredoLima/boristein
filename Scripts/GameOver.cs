using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Texture Game_Over;
	public GUIStyle EstiloDosBotoesGameOver;
	public Font Fonte;
	public int tamanhoDaLetra = 4;
	private string nomedacena = "Menu";

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		GUI.skin.font = Fonte;
		EstiloDosBotoesGameOver.fontSize = Screen.height / 100 * tamanhoDaLetra;
		GUI.skin.button = EstiloDosBotoesGameOver;
		GUI.DrawTexture (new Rect (Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 2, Screen.width, Screen.height), Game_Over);
		if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 16, Screen.height - 250f, Screen.width/8, Screen.height/14), "Menu")){
			SceneManager.LoadScene ("Menu");//NOME DA CENA DO SEU JOGO
		}
	}

}
