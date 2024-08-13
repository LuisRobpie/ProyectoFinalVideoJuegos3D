using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeLimit = 300f; // 5 minutos en segundos
    private float currentTime;

    [SerializeField] private Text timerText; // Referencia al texto UI

    void Start()
    {
        currentTime = timeLimit; // Inicia el tiempo
        UpdateTimerText(); // Actualiza el texto al iniciar
    }

    void Update()
    {
        currentTime -= Time.deltaTime; // Reduce el tiempo cada frame

        if (currentTime <= 0)
        {
            EndGame(); // Llama a la función para terminar el juego
        }

        UpdateTimerText(); // Actualiza el texto en cada frame
    }

    void EndGame()
    {
        Debug.Log("Time's up! Game Over.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar la escena
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Formato MM:SS
    }

    public float GetCurrentTime()
    {
        return currentTime; // Retorna el tiempo restante si lo necesitas en otro lugar
    }
}

