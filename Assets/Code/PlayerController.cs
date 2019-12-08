using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float view;

    private PlayerMotor motor; 

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;


        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        motor.Move(velocity);


        float yRot = Input.GetAxisRaw("Mouse X");
        
        Vector3 rotation = new Vector3(0, yRot, 0) * view;

        motor.Rotate(rotation);


        float xRot = Input.GetAxisRaw("Mouse Y");

        float cameraRotationX = xRot * view;

        motor.RotateCam(cameraRotationX);

    }
}
