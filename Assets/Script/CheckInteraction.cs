using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : MonoBehaviour
{

    public enum TypeOfDetection
    {
        PointToReceiver,
        Radial3DNoDirection,
    };

    [SerializeField]
    private TypeOfDetection typeOfDetection;

    [SerializeField]
    private float minInteractionDistance;
   
    [SerializeField]
    private GameObject rayOrigin;


    private Ray ray;

    private bool canInteract;

    private InteractionReceiver currentReceiver;

    private UI ui;




    private void Start()
    {
        ui = FindObjectOfType<UI>();

        if (typeOfDetection == TypeOfDetection.Radial3DNoDirection)
        {
            if (GetComponent<Rigidbody>()==null)
            {
                Debug.Log("The GameObject with the CheckInteraction Script requires a RigidBody component");
                Debug.Break();

            }
            if (GetComponent<SphereCollider>() == null)
            {
                Debug.Log("The GameObject with the CheckInteraction Script requires a SphereCollider component");
                Debug.Break();

            }
        }

    }

    void Update()
    {
        if (typeOfDetection == TypeOfDetection.PointToReceiver)
        {
            CheckRaycast();
            
           
            
        }

        if (canInteract)
        {
            #region ESPAÑOL
            /*
            *En esta región el personaje está viendo un objeto con el que puede interactuar
            *En mi caso voy a hacer la lectura de la tecla E aquí mismo, pero esto se puede manejar de distintas formas
            */
            #endregion

            #region ENGLISH
            /*
             *In this region the character is seeing an object with which he can interact
             *In my case I'll do the E-key reading right here, but this can be handled in different ways
            */
            #endregion

            #region DEUTSCH
            /*
             * In dieser Region sieht der Charakter ein Objekt, mit dem er interagieren kann.
             * In meinem Fall mache ich das E-Key-Lesen gleich hier, aber das kann auf 
             * verschiedene Weise gehandhabt werden.
            */
            #endregion

            ui.showMessage(currentReceiver.GetInteractionMessage());

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentReceiver.Activate();
            }

        }

    }

    private void CheckRaycast()
    {
        ray = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           

            if (hit.distance < minInteractionDistance)
            {


                currentReceiver = hit.transform.gameObject.GetComponent<InteractionReceiver>();

                if (currentReceiver != null)
                {
                    DetectingAReceiver();                 
                }
                else
                {
                    canInteract = false;
                }
            }
        }

      
    }

    private void DetectingAReceiver()
    {
        #region ESPAÑOL
        //Aquí puedes hacer algo con el mensaje de interacción
        #endregion

        #region ENGLISH
        //Here you can make something with the interact message
        #endregion

        #region DEUTSCH
        //Hier kannst du etwas mit der Interaktionsbotschaft machen
        #endregion

        canInteract = true;
        Debug.Log(currentReceiver.GetInteractionMessage());

    }


    private void OnTriggerStay(Collider other)
    {
        if (typeOfDetection == TypeOfDetection.Radial3DNoDirection)
        {
            if (other.gameObject.GetComponent<InteractionReceiver>() != null)
            {
                currentReceiver = other.gameObject.GetComponent<InteractionReceiver>();
                DetectingAReceiver();

            }

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (typeOfDetection == TypeOfDetection.Radial3DNoDirection)
        {
            if (other.gameObject.GetComponent<InteractionReceiver>() != null)
            {
               
                currentReceiver =null;
            
                canInteract = false;
            }
        }
    }


}
