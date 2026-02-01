using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void ResetGame()
    {
        SceneManager.LoadScene("PuebloScene");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
