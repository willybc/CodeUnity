using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //Gets a movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Get a rotational vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //Perform rotation
    //Perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        //if (cam != null)
        //{
            // Set our rotation and clamp it
          //  currentCameraRotationX -= cameraRotationX;
          //  currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            //Apply our rotation to the transform of our camera
           // cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
       // }

    }
}