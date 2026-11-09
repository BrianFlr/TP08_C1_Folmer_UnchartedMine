using UnityEngine;

public class EnemyBlueGolemDamage : MonoBehaviour
{
    [SerializeField] EnemiesDataSo data;

    private float damage = 0f;

    private void Start()
    {
        damage = data.blueGolemDamage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ReceiveDamage(damage);
        }
    }
}
