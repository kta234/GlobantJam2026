using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour
{
    // Variable que indica si el juego está en pausa
    private bool isPaused = false;
    public GameObject menuPausa;

    void Start()
    {
        // Asegura que el componente empiece oculto
        if (menuPausa != null)
            Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }

    private void Update()
    {
        // Detecta si el jugador presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {

            TogglePause();
            Debug.Log("escape");
        }

    }



    public void TogglePause()
    {
        // Cambia el estado de pausa (true ↔ false)
        isPaused = !isPaused;


        // Si está en pausa, el tiempo se detiene (0)
        // Si no, el tiempo vuelve a la normalidad (1)
        Time.timeScale = isPaused ? 0f : 1f;
        // Muestra u oculta el componente
        if (menuPausa != null)
            menuPausa.SetActive(isPaused);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadMenuPrincipal()
    {
        Debug.Log("Menu principal");
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        // Verificamos si estamos en el Editor de Unity
#if UNITY_EDITOR
        // Si estamos en el editor, detenemos la ejecución del juego
        EditorApplication.isPlaying = false;
#else
            // Si estamos en la compilación, salimos del juego
            Application.Quit();
#endif
    }
    

}
