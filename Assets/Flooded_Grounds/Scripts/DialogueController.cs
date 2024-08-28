using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    Dialogue dialogue;

    [SerializeField]
    DialogueManager dialogueManager;

    [SerializeField]
    GameObject interactuarBtn; 

    private bool isPlayerNearby = false; 

    private void Start()
    {
        interactuarBtn.SetActive(false);
    }

    private void Update()
    {
       
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Mouse0))
        {
            interactuarBtn.SetActive(false); 
            dialogueManager.StartDialogue(dialogue); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactuarBtn.SetActive(true); 
            isPlayerNearby = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactuarBtn.SetActive(false); 
            isPlayerNearby = false; 
            dialogueManager.EndDialogue(); 
        }
    }
}
