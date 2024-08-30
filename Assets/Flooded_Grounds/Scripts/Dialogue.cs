using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{


    [SerializeField]
    [TextArea(3, 10)]
    string[] sentencesText;


    public string[] getSentences()
    {
        return sentencesText;
    }
}
