using UnityEngine;

public class EnemyGhostDamage : MonoBehaviour
{
    [SerializeField] EnemiesDataSo ghostData;

    private float damage = 0f;

    private void Start()
    {
        damage = ghostData.ghostDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ReceiveDamage(damage);
        }
    }
}
