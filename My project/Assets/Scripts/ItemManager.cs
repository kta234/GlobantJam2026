using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public string nombreEscenaGameWin = "GameWin";

    public int puntosParaGanar = 4;
    public AudioSource audioVictoria;
    public UnityEvent alGanar;

    private int _puntosActuales = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SumarPunto()
    {
        _puntosActuales++;
        Debug.Log($"Puntos actuales: {_puntosActuales} / {puntosParaGanar}");

        if (_puntosActuales >= puntosParaGanar)
        {
            Ganar();
            SceneManager.LoadScene(nombreEscenaGameWin);
        }
    }

    private void Ganar()
    {
        Debug.Log("¡Victoria total alcanzada!");
        if (audioVictoria != null) audioVictoria.Play();
        alGanar?.Invoke();
    }
}
