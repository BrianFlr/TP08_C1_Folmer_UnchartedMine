using System;
using System.Collections;
using UnityEngine;

public class EnemyGolemMovement : MonoBehaviour
{
    [SerializeField] private EnemiesDataSo data;

    [SerializeField] private LayerMask layerDirectionChanger;
    private Rigidbody2D rb;
    private Animator animator;

    private EnemyGolemState enemyState = EnemyGolemState.Patrol;
    private float speed = 0f;
    private float damage = 0f;
    private float rayCastWallLength = 1f;
    private bool isWallFront = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        speed = data.blueGolemSpeed;
        damage = data.blueGolemDamage;
    }

    private void FixedUpdate()
    {
        EnemyRotate();

        switch (enemyState)
        {
            case EnemyGolemState.Patrol:
                EnemyPatrol();
                break;
            case EnemyGolemState.Wait:
                StartCoroutine(EnemyWait());
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + rayCastWallLength * transform.right);
    }

    private void EnemyPatrol()
    {
        // Creo un rayo en la posicion del enemigo mirando hacia la izquierda que detecte cuándo colisiono con el layer Ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayCastWallLength, layerDirectionChanger);

        // Si el rayo colisiona con el layer de Ground va a ser true y en caso contrario, false
        isWallFront = hit.collider != null;

        if (isWallFront)
        {
            speed *= -1;

            enemyState = EnemyGolemState.Wait;
        }

        EnemyMove(speed);

        animator.Play("BlueGolem-Walk");
    }

    private IEnumerator EnemyWait()
    {
        EnemyMove(0f);
        animator.Play("BlueGolem-Idle");

        yield return new WaitForSeconds(2f);

        enemyState = EnemyGolemState.Patrol;
    }

    private void EnemyMove(float speed)
    {
        rb.linearVelocity = new Vector2(-1, 0) * speed;
    }

    private void EnemyRotate()
    {
        if (rb.linearVelocityX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
