using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    [SerializeField]
    private Color activeColor;
    [SerializeField]
    private Color inactiveColor;
    [SerializeField]
    private Material material;

    private Animator animator;


    public bool activated = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        material.color = inactiveColor;

    }
    private void Update()
    {
        if (activated)
        {
            material.color = activeColor;
        }
        else
        {
            material.color = inactiveColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isActive", true);
        activated = true;

    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isActive", false);
        activated = false;

    }


}
