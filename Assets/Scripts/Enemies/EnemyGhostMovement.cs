using UnityEngine;

public partial class EnemyGhostMovement : MonoBehaviour
{
    [SerializeField] private EnemiesDataSo ghostData;
    [SerializeField] private LayerMask playerMask;
    private Transform playerTransform;
    private Rigidbody2D rb;
    
    private GhostStateMovement actualState = GhostStateMovement.Wait;
    private Vector3 initialPosition = Vector3.zero;
    private float aggroRange = 0f;
    private float maxDistance = 5.5f;
    private float speed = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed = ghostData.ghostSpeed;
        aggroRange = ghostData.ghostAggroRange;
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        GhostRotate();

        // Analizo el estado actual del enemigo.
        switch (actualState)
        {
            case GhostStateMovement.Wait:
                WaitState();
                break;
            case GhostStateMovement.Follow:
                FollowState();
                break;
            case GhostStateMovement.Return:
                ReturnState();
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
        Gizmos.DrawWireSphere(initialPosition, maxDistance);
    }

    // Función del estado de esperar del enemigo.
    private void WaitState()
    {
        // Al estar en espera, detengo al enemigo.
        rb.linearVelocity = Vector2.zero * speed;

        // Genero un círculo para detectar si algo colisiona ingresando dentro de este.
        Collider2D playerCollision = Physics2D.OverlapCircle(transform.position, aggroRange, playerMask);

        // Si algo entra dentro del rango.
        if (playerCollision != null)
        {
            // Asigno el tranform de lo que hizo colision.
            playerTransform = playerCollision.transform;
            
            // Cambio el estado del enemigo a seguir.
            actualState = GhostStateMovement.Follow;
        }
    }

    // Función del estado de seguir del enemigo.
    private void FollowState()
    {
        // Si el jugador sale del rango, quito el estado de seguir.
        if (playerTransform == null)
        {
            // Cambio el estado del enemigo a regresar.
            actualState = GhostStateMovement.Return;

            // Corto la ejecución de la función.
            return;
        }

        // Obtengo la dirección y muevo al enemigo a esa posición.
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if(Vector2.Distance(transform.position, initialPosition) > maxDistance)
        {
            // Cambio el estado del enemigo a regresar.
            actualState = GhostStateMovement.Return;

            // Reseteo la variable para indicar que salió el player del rango.
            playerTransform = null;
        }
    }

    // Función para regresar al punto de origen.
    private void ReturnState()
    {
        // Muevo al enemigo a su posición de origen.
        Vector2 direction = (initialPosition - transform.position).normalized;
        rb.linearVelocity = direction * speed;
        
        // Si llegó a su posición inicial.
        if(Vector2.Distance(transform.position, initialPosition) < 0.1f)
        {
            // Cambio el estado del enemigo a esperar.
            actualState = GhostStateMovement.Wait;
        }
    }

    // Función para rotar al enemigo.
    private void GhostRotate()
    {
        if (rb.linearVelocityX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
