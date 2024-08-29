using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCinematic : MonoBehaviour
{

    public GameObject player;
    public GameObject EndCinematicCamera;
    public GameObject EndCinematicPanel;

    private Animator endCinematicAnimator;

    private void Start()
    {
        EndCinematicPanel.SetActive(false);

        endCinematicAnimator = EndCinematicPanel.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            EndCinematicCamera.SetActive(true);
            Invoke("ShowEndCinematicPanel", 20f);
        }
    }

    private void ShowEndCinematicPanel()
    {
        EndCinematicPanel.SetActive(true);

        endCinematicAnimator.Play("Fade Out");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
