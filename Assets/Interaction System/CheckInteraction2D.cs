using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction2D : MonoBehaviour
{
    /*ESPAÑOL
        *Solución por GameDevTraum
       * 
       * Artículo: https://gamedevtraum.com/gdt-short/sistema-de-interaccion-base-para-unity/
       * Página: https://gamedevtraum.com/es/
       * Canal: https://youtube.com/c/GameDevTraum
       * 
       * Visita la página para encontrar más soluciones, Assets y artículos
      */

    /*ENGLISH
    *Solution by GameDevTraum
    * 
    * Article: https://gamedevtraum.com/gdt-short/basic-interaction-system-for-unity/
    * Website: https://gamedevtraum.com/en/
    * Channel: https://youtube.com/c/GameDevTraum
    * 
    * Visit the website to find more articles, solutions and assets
    */

    /*DEUTSCH
    *Lösung von GameDevTraum
    * 
    * Artikel: https://gamedevtraum.com/gdt-short/grundlegendes-interaktionssystem-fuer-unity/
    * Webseite: https://gamedevtraum.com/de/
    * Kanal: https://youtube.com/c/GameDevTraum
    * 
    * Besuch die Website, um weitere Artikel, Lösungen und Hilfsmittel zu finden. 
    *
    */

    public enum TypeOfDetection
    {

       Radial2DNoDirection,

    };

    [SerializeField]
    private TypeOfDetection typeOfDetection;

    private Ray ray;

    private bool canInteract;

    private InteractionReceiver2D currentReceiver;

    private UI ui;




    private void Start()
    {
        ui = FindObjectOfType<UI>();

        if (typeOfDetection == TypeOfDetection.Radial2DNoDirection)
        {
            if (GetComponent<Rigidbody2D>() == null)
            {
                Debug.Log("The GameObject with the CheckInteraction Script requires a RigidBody2D component");
                Debug.Break();

            }
            if (GetComponent<CircleCollider2D>() == null)
            {
                Debug.Log("The GameObject with the CheckInteraction Script requires a CircleCollider2D component");
                Debug.Break();

            }
        }

    }

    void Update()
    {
        

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

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentReceiver.Activate();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (typeOfDetection == TypeOfDetection.Radial2DNoDirection)
        {
            if (collision.gameObject.GetComponent<InteractionReceiver2D>() != null)
            {
                currentReceiver = collision.gameObject.GetComponent<InteractionReceiver2D>();
                DetectingAReceiver();

            }


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (typeOfDetection == TypeOfDetection.Radial2DNoDirection)
        {
            if (collision.gameObject.GetComponent<InteractionReceiver2D>() != null)
            {

                currentReceiver = null;

                canInteract = false;
            }
        }
    }

}
