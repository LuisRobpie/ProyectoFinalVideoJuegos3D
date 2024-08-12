using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float mouseSensitivity = 80f;

    public Transform CuerpoPlayer;

    float RotacionX = 0;



   
    void Start()
    {
        
    }

   
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        RotacionX -= mouseY;

        RotacionX = Mathf.Clamp(RotacionX, -90f, 90);

        transform.localRotation=Quaternion.Euler(RotacionX,0,0);

        CuerpoPlayer.Rotate(Vector3.up * mouseX);
    }
}
