using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControladorJuego : MonoBehaviour
{
    private AudioSource music;

    [SerializeField] private float tiempoMaximo;
    [SerializeField] private Slider slider;
    [SerializeField] private Musica traerSonido;
    private float tiempoActual;
    private bool tiempoActivo = false;

    private void Start()
    {
        ActivarTemporizador();

    }
    private void Update()
    {
        if (tiempoActivo)
        {
            CambiarContador();
        }
    }
    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;
        
        if(tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }


        if(tiempoActual <=0)
        {
            Debug.Log("derrota");
            Debug.Log("------");
            CambiarTemporizador(false);
            Debug.Log("LINEA 41");
            traerSonido.GameOverAudioOn();
            Debug.Log("LINEA 43");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void CambiarTemporizador(bool estado) 
    {
        tiempoActivo = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        CambiarTemporizador(true);
        slider.maxValue = tiempoMaximo;
    }
    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }

}
