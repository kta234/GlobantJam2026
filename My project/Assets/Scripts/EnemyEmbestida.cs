using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EnemyEmbestida : MonoBehaviour
{
    // Lista global para que la SafeZone encuentre a todos los enemigos rápido
    public static List<EnemyEmbestida> AllEnemies = new List<EnemyEmbestida>();

    public float moveSpeed = 2f;
    public float tiempobusquedaMax = 3;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    public bool CanFollowPlayer;
    float tiempobusqueda = 0f;
    void OnEnable() { AllEnemies.Add(this); }
    void OnDisable() { AllEnemies.Remove(this); }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = Object.FindFirstObjectByType<PlayerController>().transform;
        //GameObject.FindGameObjectWithTag
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {

            float delta = Time.deltaTime;
            tiempobusqueda -= delta;

            if (tiempobusqueda <= 0)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = direction;
                tiempobusqueda = tiempobusquedaMax;
                Debug.Log("el tiempo = 0");
            }


            //float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
        }
    }

    void FixedUpdate()
    {
        if (target && CanFollowPlayer)
        {
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * (moveSpeed);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = 0f;
        }
    }
}
