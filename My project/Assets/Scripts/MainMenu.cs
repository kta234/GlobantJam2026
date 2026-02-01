using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void openOptionsPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void openMainMunuPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
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
    public void PlayGame()
    {
        SceneManager.LoadScene("PuebloScene");
    }


}
