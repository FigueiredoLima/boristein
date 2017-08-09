using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	Transform Player;
	private UnityEngine.AI.NavMeshAgent navMesh;
	private float DistanciaPlayer, DistanciaAIPoint;
	public float DistanciadePersepcao = 30, DistanciaDeSeguir = 20, DistanciaDeAtacar = 2, VelocidadeDePasseio = 3, VelocidadeDePerseguicao = 6, TempoPorAtaque = 1.5f, DanodoInimigo = 40;
	private bool VendoOPlayer;
	public Transform[] DestinosAleatorios;
	private int AIPointAtual;
	private bool PerseguindoAlgo, ContadorPerseguindoAlgo, atacandoAlgo;
	private float cronometroDaPerseguicao, cronometroataque;

	void Start (){
		AIPointAtual = Random.Range (0, DestinosAleatorios.Length);
		navMesh = transform.GetComponent<UnityEngine.AI.NavMeshAgent> ();
		Player = GameObject.FindGameObjectWithTag ("Player").transform;

	}
	void Update(){
		DistanciaPlayer = Vector3.Distance(Player.transform.position, transform.position);
		DistanciaAIPoint = Vector3.Distance (DestinosAleatorios [AIPointAtual].transform.position, transform.position);

		//=====================================RAYCAST==========================================
		RaycastHit hit;
		Vector3 DeOnde = transform.position;
		Vector3 ParaOnde = Player.transform.position;
		Vector3 Direction = ParaOnde - DeOnde;

		if(Physics.Raycast (transform.position, Direction, out hit, 1000) && DistanciaPlayer < DistanciadePersepcao){
			if(hit .collider.gameObject.CompareTag("Player")){
				VendoOPlayer = true;
			}else{
				VendoOPlayer = false;
			}
	}

		//====================== CHECAGENS E DECISOES DO INIMIGO =======================================

		if(DistanciaPlayer > DistanciadePersepcao){
			Passear();
			}
		if(DistanciaPlayer <= DistanciadePersepcao && DistanciaPlayer > DistanciaDeSeguir){
			if(VendoOPlayer == true){
				Perseguir();
			}else{
				Passear();
		}
		}
		if (DistanciaPlayer <= DistanciaDeSeguir && DistanciaPlayer > DistanciaDeAtacar) {
			if (VendoOPlayer == true) {
				Perseguir();
				PerseguindoAlgo = true;
			}else{
				Passear ();
			}
		}
		if (DistanciaPlayer <= DistanciaDeAtacar) {
			Atacar ();
		}
		//COMANDOS DE PASSEAR
		if (DistanciaAIPoint <= 2) {
			AIPointAtual = Random.Range (0, DestinosAleatorios.Length);
			Passear ();
		}
		//CONTADORES DE PERSEGUIÇAO
		if (ContadorPerseguindoAlgo == true) {
			cronometroDaPerseguicao += Time.deltaTime;
		}
		if (cronometroDaPerseguicao >= 5 && VendoOPlayer == false) {
			ContadorPerseguindoAlgo = false;
			cronometroDaPerseguicao = 0;
			PerseguindoAlgo = false;
		}
		// CONTADOR DO ATAQUE
		if (atacandoAlgo == true) {
			cronometroataque += Time.deltaTime;
		}
		if (cronometroataque >= TempoPorAtaque && DistanciaPlayer <= DistanciaDeAtacar) {
			atacandoAlgo = true;
			cronometroataque = 0;
			PLAYER.VIDA = PLAYER.VIDA - 10;
		} else if (cronometroataque >= TempoPorAtaque && DistanciaPlayer > DistanciaDeAtacar) {
			atacandoAlgo = false;
			cronometroataque = 0;
		}
	}
	void Passear (){
		if (PerseguindoAlgo == false) {
			navMesh.acceleration = 5;
			navMesh.speed = VelocidadeDePasseio;
			navMesh.destination = DestinosAleatorios [AIPointAtual].position;
		} else if (PerseguindoAlgo == true) {
			ContadorPerseguindoAlgo = true;
		}
	}
	void Olhar (){
		navMesh.speed = 0;
		transform.LookAt (Player);
	}
	void Perseguir (){
		navMesh.acceleration = 8;
		navMesh.speed = VelocidadeDePerseguicao;
		navMesh.destination = Player.position;
	}
	void Atacar (){
		atacandoAlgo = true;
	}


}
