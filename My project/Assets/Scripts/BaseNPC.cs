using UnityEngine;

public class BaseNPC : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    }

    public void Interact()
    {
        Debug.Log("¡Interactuaste con el objeto presionando E!");
    }

}
