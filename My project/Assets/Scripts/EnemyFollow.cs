using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFollow : MonoBehaviour
{
    // Lista global para la SafeZone
    public static List<EnemyFollow> AllEnemies = new List<EnemyFollow>();

    [Header("Configuración de Movimiento")]
    public float moveSpeed = 2f;
    public bool CanFollowPlayer = true;

    [Header("Referencias")]
    public Animator animator;
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;

    void OnEnable() { AllEnemies.Add(this); }
    void OnDisable() { AllEnemies.Remove(this); }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Buscamos al jugador automáticamente
        PlayerController player = Object.FindFirstObjectByType<PlayerController>();
        if (player != null) target = player.transform;

        // Si no asignaste el animator en el inspector, intenta buscarlo
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target && CanFollowPlayer)
        {
            // 1. Calcular dirección hacia el jugador
            Vector2 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            // 2. Gestionar el Flip (Voltear sprite)
            GestionarFlip();
        }
        else
        {
            // Si no puede seguir, la dirección de movimiento es cero para las animaciones
            moveDirection = Vector2.zero;
        }

        // 3. Actualizar Parámetros del Animator
        ActualizarAnimaciones();
    }

    void FixedUpdate()
    {
        if (target && CanFollowPlayer)
        {
            // Aplicamos velocidad física
            rb.linearVelocity = moveDirection * moveSpeed;
        }
        else
        {
            // Detención total
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    void GestionarFlip()
    {
        // Solo volteamos si el enemigo se está moviendo lateralmente
        if (moveDirection.x > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDirection.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void ActualizarAnimaciones()
    {
        if (animator != null)
        {
            // Pasamos Horizontal y Vertical (valores entre -1 y 1)
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);

            // Usamos la velocidad actual del Rigidbody para el parámetro Speed
            // Esto asegura que si el enemigo se detiene, pase a Idle
            animator.SetFloat("Speed", rb.linearVelocity.sqrMagnitude);
        }
    }
}
