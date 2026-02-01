using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour
{
    private Coroutine _resetCoroutine;
    public float DelayAfterExit = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el jugador entra y había una cuenta regresiva de 2 seg, la cancelamos
            if (_resetCoroutine != null)
            {
                StopCoroutine(_resetCoroutine);
                _resetCoroutine = null;
            }

            // Desactivamos el seguimiento en todos los enemigos
            SetEnemiesFollow(false);
            SetEnemiesFollowEmbestida(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("JugadorSaliooooooooooooooooooooo");

            // Si sale, iniciamos la espera de 2 segundos
            // Guardamos la corrutina en la variable para poder cancelarla si vuelve a entrar
            if(this.isActiveAndEnabled) _resetCoroutine = StartCoroutine(WaitAndEnableFollow());
        }
    }

    private IEnumerator WaitAndEnableFollow()
    {
        yield return new WaitForSeconds(DelayAfterExit);

        // Si pasaron los 2 segundos sin interrupción, activamos a los enemigos
        SetEnemiesFollow(true);
        SetEnemiesFollowEmbestida(true);
        _resetCoroutine = null;
    }
    private void SetEnemiesFollow(bool state)
    {
        foreach (EnemyFollow enemy in EnemyFollow.AllEnemies)
        {
            if (enemy != null)
            {
                enemy.CanFollowPlayer = state;
            }
        }
        Debug.Log(state ? "Enemigos persiguiendo" : "Enemigos en pausa (Zona Segura)");
    }
    private void SetEnemiesFollowEmbestida(bool state)
    {
        foreach (EnemyEmbestida enemy in EnemyEmbestida.AllEnemies)
        {
            if (enemy != null)
            {
                enemy.CanFollowPlayer = state;
            }
        }
        Debug.Log(state ? "Enemigos persiguiendo" : "Enemigos en pausa (Zona Segura)");
    }
}
