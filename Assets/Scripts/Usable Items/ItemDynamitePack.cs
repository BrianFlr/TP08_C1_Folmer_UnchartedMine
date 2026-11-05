using System.Collections;
using UnityEngine;

public class ItemDynamitePack : MonoBehaviour
{
    [SerializeField] private UsableItemsDataSo data;
    [SerializeField] private LayerMask hitMask;
    private Animator animator;

    private float dynamitePackDamage = 0f;
    private float dynamitePackDamageRange = 0f;
    private float dynamitePackTimer = 0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        dynamitePackDamage = data.dynamitePackDamage;
        dynamitePackDamageRange = data.dynamitePackDamageRange;
        dynamitePackTimer = data.dynamitePackTimer;
    }

    private void OnEnable()
    {
        StartCoroutine(ActiveDynamitePack());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dynamitePackDamageRange);
    }

    private IEnumerator ActiveDynamitePack()
    {
        //animator.Play("DynamitePackActive");

        yield return new WaitForSeconds(dynamitePackTimer);

        Collider2D[] damagedGameObjects = Physics2D.OverlapCircleAll(transform.position, dynamitePackDamageRange, hitMask);

        foreach (Collider2D gameObject in damagedGameObjects)
        {
            DamagePlayer(gameObject);
            DamageEnemies(gameObject);
            DamageMiningNode(gameObject);
        }

        Destroy(gameObject);
    }

    private void DamagePlayer(Collider2D player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ReceiveDamage(dynamitePackDamage);
        }
    }

    private void DamageEnemies(Collider2D enemy)
    {
        EnemiesHealth enemyHealth = enemy.GetComponent<EnemiesHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.ReceiveDamage(dynamitePackDamage);
        }
    }

    private void DamageMiningNode(Collider2D miningNode)
    {
        MiningNodeHealth miningNodeHealth = miningNode.GetComponent<MiningNodeHealth>();

        if (miningNodeHealth != null)
        {
            miningNodeHealth.ReceiveDamage(dynamitePackDamage);
        }
    }
}
