using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireEffect : MonoBehaviour
{
    public GameObject damageImage; 
    public float displayTime = 1.0f; 

    void Start()
    {
        if (damageImage != null)
        {
            damageImage.SetActive(false); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (damageImage != null)
            {
                StartCoroutine(ShowDamageEffect());
            }
        }
    }

    private IEnumerator ShowDamageEffect()
    {
        damageImage.SetActive(true); 
        yield return new WaitForSeconds(displayTime); 
        damageImage.SetActive(false); 
    }
}

