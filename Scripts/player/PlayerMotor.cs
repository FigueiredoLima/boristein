using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Camera _camera;

    private Rigidbody rb;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        _camera = GetComponentInChildren<Camera>();
    }

    public void Move(Vector3 velocity)
    {
        this.velocity = velocity;
    }
    public void Rotate(Vector3 rotation)
    {
        this.rotation = rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        this.cameraRotation = _cameraRotation;
    }



    // Update is called once per frame
    void FixedUpdate () {
        PerformMovement();
        PerformRotation();
	}

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }

    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        _camera.transform.Rotate(-cameraRotation);
    }

    public Camera Camera
    {
        get { return _camera;}
        set { _camera = value;}
    }
}
