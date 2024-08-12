using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta2 : MonoBehaviour
{

    public float speed2;
    public float angle2;
    public Vector3 direction2;

    public bool PosibleAbrir2;

    void Start()
    {
        angle2 = transform.eulerAngles.y;

    }

    void Update()
    {
        if (Mathf.Round(transform.eulerAngles.y) != angle2)
        {
            transform.Rotate(direction2 * speed2 * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1") && PosibleAbrir2 == true)
        {
            angle2 = 80;
            direction2 = Vector3.up;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PosibleAbrir2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PosibleAbrir2 = false;
        }
    }
}
