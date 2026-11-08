using System.Collections;
using UnityEngine;
using static UnityEngine.LowLevelPhysics2D.PhysicsShape.SurfaceMaterial;

public class ItemDynamitePack : MonoBehaviour
{
    [SerializeField] private UsableItemsDataSo data;
    [SerializeField] private LayerMask hitMask;
    [SerializeField] private GameObject explosionEffectPrefab;

    private float dynamitePackDamage = 0f;
    private float dynamitePackDamageRange = 0f;
    private float dynamitePackTimer = 0f;

    private void OnEnable()
    {
        dynamitePackDamage = data.dynamitePackDamage;
        dynamitePackDamageRange = data.dynamitePackDamageRange;
        dynamitePackTimer = data.dynamitePackTimer;

        StartCoroutine(ActiveDynamitePack());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dynamitePackDamageRange);
    }

    private IEnumerator ActiveDynamitePack()
    {
        yield return new WaitForSeconds(dynamitePackTimer);

        Collider2D[] damagedGameObjects = Physics2D.OverlapCircleAll(transform.position, dynamitePackDamageRange, hitMask);

        foreach (Collider2D gameObject in damagedGameObjects)
        {
            DamagePlayer(gameObject);
            DamageEnemies(gameObject);
            DamageMiningNode(gameObject);
            DamageObstaclesRock(gameObject);
        }

        Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        GameManager.Instance.SetDynamitePack(false);
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

    private void DamageObstaclesRock(Collider2D obstacleRock)
    {
        ObstacleRockHealth obstacleRockHealth = obstacleRock.GetComponent<ObstacleRockHealth>();

        if (obstacleRockHealth != null)
        {
            obstacleRockHealth.ReceiveDamage(dynamitePackDamage);
        }
    }
}
