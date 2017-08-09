using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	private AudioListener[] AudioListners;
	public Texture QualidadeGrafica, Resolucoes, ModoJanelaOuTelaCheia, Volume, TexturaCreditos, TexturaFundosMenu, TexturaGraficos;
	private bool EstaNoMenuPrincipal, EstaNosGraficos, EstaNosCreditos;
	public GUIStyle EstiloDosBotoesPrincipais, EstiloDosGraficos;
	private string ResolucaoLargura = "1024", ResolucaoAltura = "768";
	private float VOLUME;
	private int qualidadeGrafica;
	public Font Fonte;
	public int tamanhoDaLetra = 4;
	private string nomedacena = "Menu";

	void Awake (){
		DontDestroyOnLoad (transform.gameObject);	//Para não destruir o Objeto quando fizer load em outra cena	
	}
	void Start (){
		EstaNoMenuPrincipal = true;
		Cursor.visible = true;
		Time.timeScale = 1;
		// PREFERENCIAS SALVAS
		if (PlayerPrefs.HasKey ("VOLUME")) {
			VOLUME = PlayerPrefs.GetFloat ("VOLUME");
		} else {
			PlayerPrefs.SetFloat ("VOLUME", VOLUME);
		}
		//
		if (PlayerPrefs.HasKey ("qualidadeGrafica")) {
			qualidadeGrafica = PlayerPrefs.GetInt ("qualidadeGrafica");
			QualitySettings.SetQualityLevel (qualidadeGrafica);
		} else {
			PlayerPrefs.SetInt ("qualidadeGrafica", qualidadeGrafica);
		}

	}

	void Update (){
		//Preencher Arrays
		if (SceneManager.GetActiveScene ().name != nomedacena) {
			AudioListners = GameObject.FindObjectsOfType (typeof(AudioListener)) as AudioListener[];
			AudioListener.volume = VOLUME;
			Destroy (gameObject);
		}
	}

	void OnGUI (){
		GUI.skin.font = Fonte;
		EstiloDosBotoesPrincipais.fontSize = Screen.height / 100 * tamanhoDaLetra;
		EstiloDosGraficos.fontSize = Screen.height / 100 * tamanhoDaLetra;
		//==============================================SE ESTA NA PARTE PRINCIPAL DO MENU ============================//
		if(EstaNoMenuPrincipal == true){
			GUI.skin.button = EstiloDosBotoesPrincipais;
			GUI.DrawTexture (new Rect (Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 2, Screen.width, Screen.height), TexturaFundosMenu);
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height / 5.5f, Screen.width/8, Screen.height/14), "Jogar")){
				SceneManager.LoadScene ("Jogo");//NOME DA CENA DO SEU JOGO
			}
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height /16, Screen.width/8, Screen.height/14), "Opçoes")){
				EstaNoMenuPrincipal = false;
				EstaNosGraficos = true;
			}
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 + Screen.height / 16, Screen.width/8, Screen.height/14), "Creditos")){
				EstaNoMenuPrincipal = false;
				EstaNosCreditos = true;
			}
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 + Screen.height / 5.5f, Screen.width/8, Screen.height/14), "Sair")){
				Application.Quit ();
			}
		}

		//==============================================SE ESTA NA PARTE DOS GRAFICOS =================================//
		if(EstaNosGraficos == true){
			GUI.skin.button = EstiloDosGraficos;
			GUI.DrawTexture (new Rect (Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 2, Screen.width, Screen.height), TexturaGraficos);
			GUI.DrawTexture (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 2.5f, Screen.width/8, Screen.height/14), QualidadeGrafica);
			GUI.DrawTexture (new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height / 2.5f, Screen.width/8, Screen.height/14), Resolucoes);
			GUI.DrawTexture (new Rect (Screen.width / 2 + Screen.width / 5, Screen.height / 2 - Screen.height / 2.5f, Screen.width/8, Screen.height/14), ModoJanelaOuTelaCheia);
			GUI.DrawTexture (new Rect (Screen.width / 2 + Screen.width / 5, Screen.height / 2 - Screen.height / 10, Screen.width/8, Screen.height/14), Volume);
			//
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 2.2f, Screen.height / 2 + Screen.height / 2.5f, Screen.width/8, Screen.height/14), "VOLTAR")){
				EstaNoMenuPrincipal = true;
				EstaNosGraficos = false;
			}
			//QUALIDADES
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 4, Screen.width/8, Screen.height/14), "PESSIMO")){
				QualitySettings.SetQualityLevel (0);
				qualidadeGrafica = 0;
			}
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 6, Screen.width/8, Screen.height/14), "RUIM")){
				QualitySettings.SetQualityLevel (1);
				qualidadeGrafica = 1;
			}
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 12, Screen.width/8, Screen.height/14), "SIMPLES")){
				QualitySettings.SetQualityLevel (2);
				qualidadeGrafica = 2;
			}
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2, Screen.width/8, Screen.height/14), "BOM")){
				QualitySettings.SetQualityLevel (3);
				qualidadeGrafica = 3;
			}
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 12, Screen.width/8, Screen.height/14), "OTIMO")){
				QualitySettings.SetQualityLevel (4);
				qualidadeGrafica = 4;
			}
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 6, Screen.width/8, Screen.height/14), "FANTASTICO")){
				QualitySettings.SetQualityLevel (5);
				qualidadeGrafica = 5;
			}
			//RESOLUÇÕES
			ResolucaoLargura = GUI.TextField(new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height / 4, Screen.width/8, Screen.height/14), ResolucaoLargura);
			ResolucaoAltura = GUI.TextField(new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height / 5.5f, Screen.width/8, Screen.height/14), ResolucaoAltura);
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height / 12, Screen.width / 8, Screen.height / 14), "Aplicar")) {
				Screen.SetResolution (int.Parse (ResolucaoLargura), int.Parse (ResolucaoAltura), true);
			}
			//TELACHEIA
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 5, Screen.height / 2 - Screen.height / 4, Screen.width/8, Screen.height/14), "Trocar")) {
				Screen.fullScreen = !Screen.fullScreen;
			}
			//VOLUME
			VOLUME = GUI.HorizontalSlider(new Rect(Screen.width / 2 + Screen.width / 5, Screen.height / 2, Screen.width/8, Screen.height/14), VOLUME, 0,1);
			//SALVAR PREFERENCIAS
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 5, Screen.height / 2 + Screen.height / 3, Screen.width/8, Screen.height/14), "SALVAR PREF.")) {
				PlayerPrefs.SetFloat ("VOLUME", VOLUME);
				PlayerPrefs.SetInt ("qualidadeGrafica", qualidadeGrafica);
			}


		}
		//==============================================SE ESTA NA PARTE DOS CREDITOS =================================//
		if(EstaNosCreditos == true){
			GUI.DrawTexture (new Rect (Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 2, Screen.width, Screen.height), TexturaCreditos);
			GUI.skin.button = EstiloDosGraficos;
			if(GUI.Button (new Rect (Screen.width / 2 - Screen.width / 2.2f, Screen.height / 2 + Screen.height / 2.5f, Screen.width/8, Screen.height/14), "Voltar")){
				EstaNoMenuPrincipal = true;
				EstaNosCreditos = false;
			}
		}

	}


}
