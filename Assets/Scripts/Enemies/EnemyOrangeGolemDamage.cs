using UnityEngine;

public class EnemyOrangeGolemDamage : MonoBehaviour
{
    [SerializeField] EnemiesDataSo orangeGolemData;

    private float damage = 0f;

    private void Start()
    {
        damage = orangeGolemData.orangeGolemDamage;
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
