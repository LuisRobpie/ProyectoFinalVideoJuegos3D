using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    [SerializeField]
    Animator[] animators;

    [SerializeField]
    Animator key;

    [SerializeField]
    PickUpObject objeto;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                checkKnife();
            }
        }
    }
    private void checkKnife()
    {
        if (objeto.PickedObject != null)
        {
            if (objeto.PickedObject.CompareTag("Knife"))
            {
                foreach (var animator in animators)
                {
                    animator.SetTrigger("CutRope");
                }
                key.SetTrigger("dropKey");
            }
        }
    }


}
