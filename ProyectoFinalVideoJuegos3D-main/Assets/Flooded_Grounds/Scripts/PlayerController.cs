using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 1.0f;

    public float gravedad = -9.8f;

    public float SaltoAltura = 3;

    public Transform CheckGround;

    public float DistanceGround = 0.3f;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;


   
    void Start()
    {
        
    }


    void Update()
    {

        isGrounded = Physics.CheckSphere(CheckGround.position, DistanceGround, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;

        }


        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;

        controller.Move(mover * speed * Time.deltaTime);

        velocity.y += gravedad * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        
    }
}
