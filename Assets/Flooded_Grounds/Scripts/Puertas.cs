using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{

    public float speed;
    public float angle;
    public Vector3 direction;

    public bool PosibleAbrir;

    void Start()
    {
        angle = transform.eulerAngles.y;
        
    }
 
    void Update()
    {
        if (Mathf.Round(transform.eulerAngles.y) != angle)
        {
            transform.Rotate(direction * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1") && PosibleAbrir == true)
        {
            angle = 180;
            direction = Vector3.up;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PosibleAbrir = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PosibleAbrir = false;
        }
    }
}
