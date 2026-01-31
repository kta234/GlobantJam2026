using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public IInteractable _currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        // Intentamos obtener la interfaz del objeto que tocamos
        if (other.TryGetComponent(out IInteractable interactable))
        {
            _currentInteractable = interactable;
            _currentInteractable.Touch(); // Ejecuta Touch al entrar
        }
    }

    private void Update()
    {
        // Si hay un objeto en rango y presionamos E
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("¡Interactuar!");
            if (_currentInteractable != null)
            {
                _currentInteractable.Interact();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el objeto que sale es el que teníamos guardado, limpiamos la referencia
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (_currentInteractable == interactable)
            {
                _currentInteractable = null;
            }
        }
    }
}
