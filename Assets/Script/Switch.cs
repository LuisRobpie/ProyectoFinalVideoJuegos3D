using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour , IAction
{
  

    [SerializeField]
    private Color activeColor;
    [SerializeField]
    private Color inactiveColor;
    [SerializeField]
    private Material material;

    public GameObject Key;

    private bool activated;

    public void Start()
    {
        material.color = inactiveColor;

    }

    public void Activate()
    {
        activated = !activated;
        if (activated)
        {
            Key.SetActive(true);
            material.color = activeColor;
        }
        else
        {
            material.color = inactiveColor;
        }

    }

}
