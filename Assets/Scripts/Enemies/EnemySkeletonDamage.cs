using UnityEngine;

public class EnemySkeletonDamage : MonoBehaviour
{
    [SerializeField] EnemiesDataSo skeletonData;

    private float damage= 0f;

    private void Start()
    {
        damage = skeletonData.skeletonDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.ReceiveDamage(damage);
        }
    }
}
