using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject dialoguePanel;

    private Queue<string> _sentences;
    private TextMeshProUGUI sentencesText;

    public static bool isDialogueActive { get; private set; } = false;

    private void Awake()
    {
        _sentences = new Queue<string>();
        sentencesText = dialoguePanel.GetComponentInChildren<TextMeshProUGUI>();
        
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        StartCoroutine(StartDialogueCoroutine(dialogue));
    }

    public IEnumerator StartDialogueCoroutine(Dialogue dialogue)
    {
        yield return new WaitForSeconds(0.5F);
        _sentences.Clear();
        
        foreach (string sentence in dialogue.getSentences())
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        StartCoroutine(EndDialogueCoroutine());
    }

    private IEnumerator EndDialogueCoroutine()
    {
        yield return new WaitForSeconds(0.5F);
        dialoguePanel.SetActive(false);
    }

    private IEnumerator TypeSentence(string sentence)
    {
        sentencesText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            sentencesText.text += letter;
            yield return null;
        }
    }
}
