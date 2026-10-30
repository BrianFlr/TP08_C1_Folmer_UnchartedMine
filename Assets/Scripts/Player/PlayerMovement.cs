using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private LayerMask layerGround;
  
    private Rigidbody2D rb;
    private float playerSpeed = 0f;
    private float playerJumpForce = 0f;
    private float rayCastLength = 0.45f;
    
    private bool isGround = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerSpeed = data.speed;
        playerJumpForce = data.jumpForce;
    }

    private void FixedUpdate()
    {
        // Creo un rayo en la posicion del player mirando hacia abajo que detecte cuándo colisiono con el layer Ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCastLength, layerGround);

        // Si el rayo colisiona con el layer de Ground va a ser true y en caso contrario, false
        isGround = hit.collider != null;

        // Movimiento jugador
        if (Input.GetKey(data.moveLeft))
        {
            rb.linearVelocity = new Vector2(-1 * playerSpeed, rb.linearVelocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(data.moveRight))
        {
            rb.linearVelocity = new Vector2(1 * playerSpeed, rb.linearVelocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Si está en el suelo el player puede saltar
        if (isGround)
        {
            if (Input.GetKey(data.jump))
            {
                rb.linearVelocity = new Vector2(0, 1) * playerJumpForce;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayCastLength);
    }

    // Función para rotar al player.
    private void RotatePlayer()
    {
        if(rb.linearVelocityX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public bool GetIsGroundState()
    {
        return isGround;
    }
}
