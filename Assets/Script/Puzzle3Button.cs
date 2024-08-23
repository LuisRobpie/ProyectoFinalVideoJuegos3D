using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle3Button : MonoBehaviour, IAction
{
    [SerializeField]
    public GameObject Key;
    private bool activated;



    // Start is called before the first frame update
    void Start()
    {
        Key.SetActive(false);
    }

    void FixedUpdate()
    {
        if (activated)
        {
            Key.SetActive(true);

        }
        else
        {
           
        }
    }
    public void Activate()
    {
        activated = !activated;
        if (activated)
        {
            
            Debug.Log("Gate activated");
        }
        else
        {
            Debug.Log("Gate deactivated");

        }
    }
}
