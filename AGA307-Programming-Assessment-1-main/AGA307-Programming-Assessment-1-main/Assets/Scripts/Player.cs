using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public float jumpHeight = 3f;

    [Header("Ground Settings")]
    [SerializeField] bool isGrounded;
    public Vector3 groundCheckPos = new Vector3(0, -0.8f, 0);
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Look Settings")]
    public float mouseSensitivity = 500f;
    public Camera fpsCam;
    float xRotation = 0f;

    [Header("Components")]
    public CharacterController controller;
    public Gun gun;

    void Start()
    {
        //search object for character controller
        controller = this.GetComponent<CharacterController>();
        fpsCam = this.GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(this.transform.TransformPoint(groundCheckPos), groundDistance, groundMask);
        Move();
        Look();
        
        if(Input.GetMouseButtonDown(0))
            gun.Shoot();
    }

    void Move()
	{
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float yVel = velocity.y;
        velocity = (transform.right * x + transform.forward * z).normalized;
        velocity *= speed;
        velocity.y = yVel;
        velocity.y += gravity * Time.deltaTime;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        

        

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        

        controller.Move(velocity * Time.deltaTime);

        
    }

    void Look()
	{
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        fpsCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        this.transform.Rotate(Vector3.up * mouseX);
    }

    private void OnDrawGizmos()
	{
        //draw a coloured wire sphere if player is grounded
       
        if(isGrounded)
           Gizmos.color = Color.green;
        else
           Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(this.transform.TransformPoint(groundCheckPos), groundDistance);

	}
}
