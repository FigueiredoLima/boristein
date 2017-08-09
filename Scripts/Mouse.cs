using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public Texture2D pontomiraa;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.Escape))||(PLAYER.VIDA <=0)){
			Screen.lockCursor = false;
		}else{
			Screen.lockCursor = true;
		}
	}
	void OnGUI () {

		GUI.Label(new Rect(Screen.width /2f,Screen.height /2f - 75f,Screen.width * 0.05f,Screen.height * 0.05f),pontomiraa);

	}


}
