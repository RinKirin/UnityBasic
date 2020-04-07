using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFPController : MonoBehaviour
{
    public Transform cam;
    public CharacterController character;

    public float grav = -22.81f;
    public float speed = 3f;
    public float jumpHeight = 2;
    Vector3 velocity;

    public float rX;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotateAndMoveCamera();

        if (cam.position.y < -200)
            cam.position = new Vector3(cam.position.x, 15, cam.position.z);
    }

    private void rotateAndMoveCamera()
    {
        if (character.isGrounded && velocity.y<0)
            velocity.y = -2;

        float mY = Input.GetAxis("Mouse Y");
        float mX = Input.GetAxis("Mouse X");

        Vector3 rot = cam.rotation.eulerAngles;
        rot.x -= mY;
        rot.y += mX;
        rX -= mY;
        rX = Mathf.Clamp(rX, -90f, 90f);
        rot.x = rX;

        cam.localRotation = Quaternion.Euler(rot);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        character.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && velocity.y == -2)
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*grav);

        velocity.y += (grav * Time.deltaTime);

        character.Move(velocity * Time.deltaTime);
    }
}
