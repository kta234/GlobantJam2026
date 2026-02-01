using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float movementSpeed = 5f;

    [Header("Referencias")]
    public Animator animator;
    public Interactor interactor;
    public GameObject menuPausa;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isPaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Verificación de seguridad
        if (interactor == null) interactor = GetComponent<Interactor>();
    }

    void Update()
    {
        // 1. Obtener Input (8 direcciones)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 2. Lógica de Interacción (Presionando E)
        // Nota: Asegúrate de que '_currentInteractable' sea público en tu clase Interactor
        if (interactor != null && interactor._currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            interactor._currentInteractable.Interact();
        }

        // 3. Voltear el Sprite (Flip)
        GestionarFlip();

        // 4. Actualizar Parámetros del Animator
        ActualizarAnimaciones();
    }

    void FixedUpdate()
    {
        // 5. Movimiento Normalizado
        // Si la magnitud es mayor a 1 (diagonal), normalizamos. Si no, dejamos el valor crudo
        // para permitir movimientos lentos si usas un joystick.
        Vector2 velocity = movement.magnitude > 1 ? movement.normalized : movement;

        rb.linearVelocity = velocity * movementSpeed;
    }

    void GestionarFlip()
    {
        // Si se mueve a la derecha, escala positiva
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Si se mueve a la izquierda, escala negativa en X
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void ActualizarAnimaciones()
    {
        if (animator != null)
        {
            // Pasamos los valores al animator
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            // Usamos la magnitud para la transición Idle -> Walk
            // Usamos el vector sin normalizar para que 'Speed' sea 0 cuando no hay inpu
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }
}
