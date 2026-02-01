using UnityEngine;
using UnityEngine.UI;
public class ControladorJuego : MonoBehaviour
{
    [SerializeField] private float tiempoMaximo;
    [SerializeField] private Slider slider;
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
            CambiarTemporizador(false);
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
