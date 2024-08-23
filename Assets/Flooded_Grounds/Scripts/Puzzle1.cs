using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{

    [SerializeField]
    PlateController[] plates;

    [SerializeField]
    GameObject Key;

    int plateAmount;
    int activePlates;
    private void Start()
    {
        plateAmount = plates.Length;
        Key.SetActive(false);
    }

    private void Update()
    {
        foreach (var plate in plates)
        {
            checkPlates(plate);
        }
        checkPuzzle();
    }

    private void checkPlates( PlateController plate)
    {
        if(plate.activated == true)
        {
            activePlates++;
        }
    }

    private void checkPuzzle()
    {
        if(activePlates == plateAmount)
        {
            Debug.Log("Completado");
            Key.SetActive(true);
        }
        else if (activePlates != plateAmount)
        {
            Debug.Log("Incompleto");
            activePlates = 0;
        }
    }
}
