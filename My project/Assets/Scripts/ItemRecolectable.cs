using UnityEngine;

public class ItemRecolectable : MonoBehaviour, IInteractable
{
    [Header("Configuración de Recolección")]
    public GameObject objetoAActivar;
    public AudioClip sonidoRecoleccion;
    public GameObject indicadorVisual; // Un icono de "E" o un brillo

    [Header("Ajustes")]
    [Range(0, 1)] public float volumenSonido = 1f;

    // Se ejecuta cuando el Interactor entra en el Collider
    public void Touch()
    {
        Debug.Log("Objeto recolectado mediante interacción.");

        /*
        if (indicadorVisual != null)
        {
            indicadorVisual.SetActive(true);
            Debug.Log("Cerca del objeto. Presiona E para recoger.");
        }
        */
        // 1. Sumar punto al GameManager
        if (ItemManager.Instance != null)
        {
            ItemManager.Instance.SumarPunto();
        }

        // 2. Activar el objeto especial (puerta, luz, etc.)
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }

        // 3. Sonido (usamos PlayClipAtPoint porque vamos a destruir el objeto)
        if (sonidoRecoleccion != null)
        {
            AudioSource.PlayClipAtPoint(sonidoRecoleccion, transform.position, volumenSonido);
        }

        Debug.Log("Objeto recolectado mediante interacción.");

        // 4. ¡Adiós!
        Destroy(gameObject);
    }

    // Se ejecuta cuando el usuario presiona "E"
    public void Interact()
    {

    }

    // Se ejecuta cuando el Interactor sale del Collider
    public void Release()
    {
        if (indicadorVisual != null)
        {
            indicadorVisual.SetActive(false);
        }
    }
}
