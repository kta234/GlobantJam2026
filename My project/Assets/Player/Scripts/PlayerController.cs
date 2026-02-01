using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rb;
    public Animator animator;
    public Interactor interactor;
    Vector2 movement;
    // Variable que indica si el juego está en pausa
    private bool isPaused = false;
    public GameObject menuPausa;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {



        // Si hay un objeto en rango y presionamos E
        if (interactor._currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            interactor._currentInteractable.Interact();
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector2(movement.x * movementSpeed, movement.y * movementSpeed);
    }


}
