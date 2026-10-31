using System;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public event Action onPlayerAttack;

    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private LayerMask enemiesMask;
    [SerializeField] private Transform attackPoint;
    private PlayerMovement PlayerMovement;
    private Rigidbody2D rb;

    [SerializeField] private float attackRadius = 0.3f;
    private float attackCooldown = 0f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        attackCooldown = playerData.attackCooldown;
    }

    private void FixedUpdate()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetMouseButtonDown((int)playerData.meleeAttack) && PlayerMovement.GetIsGroundState())
            {
                PlayerAttack();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRadius);
    }

    private void PlayerAttack()
    {
        onPlayerAttack?.Invoke();

        nextAttackTime = Time.time + attackCooldown;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, enemiesMask);

        foreach (Collider2D enemyGameObject in enemies)
        {
            Debug.Log("hit enemy");
        }
    }



}
