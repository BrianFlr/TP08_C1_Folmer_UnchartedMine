using System;
using System.Collections;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public event Action onPlayerAttack;

    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private LayerMask enemiesMask;
    [SerializeField] private Transform attackPoint;
    private PlayerMovement PlayerMovement;
    private Rigidbody2D rb;

    private bool isAttacking = false;

    [SerializeField] private float attackRadius = 0.3f;
    private float attackCooldown = 0f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
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

    public bool GetAttackingState()
    {
        return isAttacking;
    }

    // Ataque del jugador.
    private IEnumerator IsAttack()
    {
        isAttacking = true;
        onPlayerAttack?.Invoke();
        nextAttackTime = Time.time + attackCooldown;

        yield return new WaitForSeconds(0.5f);

        // Creo un collider para detectar todos los objetos que se encuentran dentro del collider al momento de golpear.
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRadius, enemiesMask);

        // Aplico el daño a los enemigos llamando su función de recibir daño.
        foreach (Collider2D enemyGameObject in enemies)
        {
            Debug.Log("hit enemy");
        }

        isAttacking = false;
    }
}
