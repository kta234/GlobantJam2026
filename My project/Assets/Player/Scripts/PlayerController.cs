using UnityEngine;
using UnityEngine.InputSystem;

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
    private InputSystem_Actions inputActions;

    void Awake()
    {
        // Inicializar el Input System
        inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        // Habilitar las acciones del jugador
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        // Deshabilitar las acciones del jugador
        inputActions.Player.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Verificación de seguridad
        if (interactor == null) interactor = GetComponent<Interactor>();
    }

    void Update()
    {
        // 1. Obtener Input (8 direcciones) usando el nuevo Input System
        movement = inputActions.Player.Move.ReadValue<Vector2>();

        // 2. Lógica de Interacción (Presionando E)
        if (interactor != null && interactor._currentInteractable != null && inputActions.Player.Interact.triggered)
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
            // Usamos el vector sin normalizar para que 'Speed' sea 0 cuando no hay input
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }
}
