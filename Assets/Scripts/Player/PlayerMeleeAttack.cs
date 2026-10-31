using System;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public event Action onPlayerAttack;

    [Header("Data")]
    [SerializeField] private PlayerDataSo playerData;

    [Header("Attack Collision Mask")]
    [SerializeField] private LayerMask enemiesMask;

    [Header("Attack Point")]
    [SerializeField] private Transform attackPoint;
    private Rigidbody2D rb;

    [SerializeField] private float attackRadius = 0.3f;
    private float attackCooldown = 0f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        attackCooldown = playerData.attackCooldown;
    }

    private void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetMouseButtonDown((int)playerData.meleeAttack))
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
        nextAttackTime = Time.time + attackCooldown;

        onPlayerAttack?.Invoke();

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, enemiesMask);

        foreach (Collider2D enemyGameObject in enemies)
        {
            Debug.Log("hit enemy");
        }
    }



}
