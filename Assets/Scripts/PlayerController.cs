﻿using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(RollBall))]


public class PlayerController : MonoBehaviour {

    public GameObject Body;
    public GameObject Head;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;

        Vector3 _movVertical = transform.forward * _zMov ;

        Vector3 movement = new Vector3(_xMov, 0.0f, _zMov);
        //Condicion movimiento rotacion BODY
        if (_movVertical != Vector3.zero)
        {
            Body.transform.Rotate(new Vector3(0, 270, 0) * Time.deltaTime);
        }

        if(_movHorizontal != Vector3.zero)
        {
            Body.transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
        }
        

        // Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply movement
        motor.Move(_velocity);

        // Calculate rotation as a 3D vector
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
        //Condicion movimiento rotacion HEAD
        if (_rotation != Vector3.zero)
        {
            Head.transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
        }


        //Apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (turning around)
       // float _xRot = Input.GetAxisRaw("Mouse Y");

       // float _cameraRotationX = _xRot * lookSensitivity;

        //Apply camera rotation
       // motor.RotateCamera(_cameraRotationX);
    }
 
}
