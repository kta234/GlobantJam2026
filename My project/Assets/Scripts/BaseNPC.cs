using UnityEngine;
using TMPro;

public class BaseNPC : MonoBehaviour, IInteractable
{

    public string[] dialogos;
    public GameObject canvasDialogo;
    public TMP_Text componenteTexto;

    private bool _yaSeUso = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Touch()
    {
        Debug.Log("¡Tocaste el objeto!");
        //if (_yaSeUso) return;

        if (dialogos != null && dialogos.Length > 0)
        {
            canvasDialogo.SetActive(true); // Encendemos el UI
            componenteTexto.text = dialogos[0];
        }
    }

    public void Interact()
    {
        Debug.Log("¡Interactuaste con el objeto presionando E!");
    }

    public void Release()
    {
        Debug.Log("¡NPC fuera de rango");
        canvasDialogo.SetActive(false);
        _yaSeUso = true;
    }
}
