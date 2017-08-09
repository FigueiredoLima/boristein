#pragma strict
var pontomiraa : Texture2D;
public var isLoaded = false;

function Update () {
	if((Input.GetKeyDown(KeyCode.Escape))||(isLoaded == true)){
		Screen.lockCursor = false;
	}else{
	    	Screen.lockCursor = true;
	}
	//Screen.showCursor = false;
  }


function OnGUI () {
	GUI.Label(Rect(Screen.width /2,Screen.height /2 -55,Screen.width * 0.1,Screen.height * 0.1),pontomiraa);
}