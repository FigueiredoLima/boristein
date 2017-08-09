using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    private Behaviour[] componentsToDisable;

    private Camera sceneCamera;

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            PlayerMotor motor = GetComponent<PlayerMotor>();
            motor.Camera.enabled = false;
            for(int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }else
        {
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
	}

    
    void OnDisable()
    {
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }

}
