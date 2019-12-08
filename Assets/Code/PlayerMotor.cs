using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour{

    [SerializeField]
    private Camera cam;

    private Vector3 _velocity;
    private Vector3 rotation;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private Rigidbody rb;

    [SerializeField]
    private float cameraRotationLimit = 85f;

    private void Start()
    {
        rb = GetComponent < Rigidbody>();
    }

    public void Move(Vector3 velocity)
    {
        _velocity = velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }


    public void RotateCam(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }


     private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement(){
        if(_velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + _velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation(){
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }



}
