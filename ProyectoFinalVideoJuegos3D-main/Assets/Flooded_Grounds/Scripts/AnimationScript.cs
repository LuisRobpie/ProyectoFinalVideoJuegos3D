using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;

    private void Update()
    {
        StartCoroutine(tiempo());
    }

    IEnumerator tiempo()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(Camera, 0.1f);
        Player.SetActive(true);
    }
}
