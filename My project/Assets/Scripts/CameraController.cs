using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objetive;
    public float cameraVelocity = 0.025f;
    public Vector3 displacement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 desirePosition = objetive.position + displacement;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePosition, cameraVelocity);

        transform.position = smoothPosition;
    }
}