using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    [SerializeField]
    Animator[] animators;

    [SerializeField]
    PickUpObject objeto;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("revisando cuchillo");
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
                Debug.Log("cuchillo");
                foreach (var animator in animators)
                {
                    Debug.Log("cortando");
                    animator.SetTrigger("CutRope");
                }
            }
        }
    }


}
