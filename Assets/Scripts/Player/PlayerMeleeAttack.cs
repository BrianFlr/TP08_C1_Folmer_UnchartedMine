using System;
using System.Collections;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public event Action onPlayerAttack;

    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private LayerMask hitMask;
    [SerializeField] private Transform attackPoint;
    private PlayerMovement PlayerMovement;
    private Rigidbody2D rb;

    private bool isAttacking = false;

    private float attackDamage = 0f;
    private float attackRadius = 0f;
    private float attackCooldown = 0f;
    private float nextAttackTime = 0f;
    private float attackDelayTime = 0f;

    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Start()
    {
        attackDamage = playerData.attackDamage;
        attackRadius = playerData.attackRadius;
        attackCooldown = playerData.attackCooldown;
        attackDelayTime = playerData.attackDelayTime;
    }

    private void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetMouseButtonDown((int)playerData.meleeAttack) && PlayerMovement.GetIsGroundState())
            {
                StartCoroutine(IsAttack());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRadius);
    }

    // Ataque del jugador.
    private IEnumerator IsAttack()
    {
        isAttacking = true;
        onPlayerAttack?.Invoke();
        nextAttackTime = Time.time + attackCooldown;

        yield return new WaitForSeconds(attackDelayTime);

        // Creo un collider para detectar todos los objetos que se encuentran dentro del collider al momento de golpear.
        Collider2D[] hitGameObjects = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, hitMask);

        // Aplico el daño a los enemigos llamando su función de recibir daño.
        foreach (Collider2D hit in hitGameObjects)
        {
            HitEnemies(hit);
            HitMiningNode(hit);
        }

        isAttacking = false;
    }

    public bool GetAttackingState()
    {
        return isAttacking;
    }

    private void HitEnemies(Collider2D gameObject)
    {
        EnemiesHealth enemyHealth = gameObject.GetComponent<EnemiesHealth>();
        SpriteRenderer enemySpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

        if (enemyHealth != null)
        {
            enemyHealth.ReceiveDamage(attackDamage);
        }
    }

    private void HitMiningNode(Collider2D gameObject)
    {
        MiningNodeHealth miningNode = gameObject.GetComponent<MiningNodeHealth>();

        if (miningNode != null)
        {
            miningNode.ReceiveDamage(attackDamage);
        }
    }

    public void SetMeleeDamage(float damageAmount)
    {
        attackDamage = damageAmount;
    }
}
