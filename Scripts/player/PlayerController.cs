using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : NetworkBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensitivity = 3f;


	public GameObject tiro;
	public Transform spawtiro;

	[SyncVar]
	public float fireRate = 0.5F;

	[SyncVar]
	private float nextFire = 0.0F;


    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update () {
		if (!isLocalPlayer) {

			return;

		}
            float _xMov = Input.GetAxisRaw("Horizontal");
            float _zMov = Input.GetAxisRaw("Vertical");

            Vector3 _moveHorizontal = transform.right * _xMov;
            Vector3 _moveVertical = transform.forward * _zMov;
            Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

            motor.Move(_velocity);


				if (Input.GetMouseButtonDown (0) && (Time.time > nextFire)) {
					nextFire = Time.time + fireRate;
					CmdSpawntiro ();

			}

            float _yRot = Input.GetAxisRaw("Mouse X");
            float _xRot = Input.GetAxisRaw("Mouse Y");
            Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
            Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

            motor.Rotate(_rotation);
            motor.RotateCamera(_cameraRotation);
        }

    
	[Command]
	public void CmdSpawntiro()
	{
		GameObject bullet = (GameObject)Instantiate(tiro, spawtiro.position, spawtiro.rotation);

		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 25.0f;
		NetworkServer.Spawn(bullet);
		Destroy (bullet, 5);
	}


}
