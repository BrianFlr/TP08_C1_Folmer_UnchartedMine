using UnityEngine;

public class EnemySkeletonMovement : MonoBehaviour
{
    [SerializeField] private EnemiesDataSo skeletonData;
    [SerializeField] private LayerMask layerDirectionChanger;
    private Rigidbody2D rb;

    private bool isFrontLimit = false;
    private float speed = 0;
    private float rayCastLength = 0.65f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed = skeletonData.skeletonSpeed;
    }

    private void FixedUpdate()
    {
        // Creo un rayo en la posicion del enemigo mirando hacia la izquierda que detecte cuándo colisiono con el layer Ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * -1, rayCastLength, layerDirectionChanger);

        // Si el rayo colisiona con el layer de Ground va a ser true y en caso contrario, false
        isFrontLimit = hit.collider != null;

        if (isFrontLimit)
        {
            speed *= -1;
        }

        SkeletonMove(speed);
        SkeletonRotate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + rayCastLength * transform.right * -1);
    }

    private void SkeletonMove(float speed)
    {
        rb.linearVelocity = new Vector2(-1, 0) * speed;
    }

    private void SkeletonRotate()
    {
        if (rb.linearVelocityX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
