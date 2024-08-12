using System;
using TMPro;
using UnityEngine;

[Serializable]
public class CollectibleUI 
{
    [SerializeField]
    CollectibleType collectibleType;

    [SerializeField]
    public TextMeshProUGUI textbox;

    public CollectibleType GetCollectibleType() 
    { return collectibleType; }

    public TextMeshProUGUI GetTextbox() 
    {  return textbox; }
}