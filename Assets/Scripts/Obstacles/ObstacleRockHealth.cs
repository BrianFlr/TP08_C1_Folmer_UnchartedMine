using UnityEngine;

public class ObstacleRockHealth : MonoBehaviour
{
    [SerializeField] private ObstaclesDataSo data;

    private float health = 0f;

    private void Start()
    {
        health = data.health;
    }

    public void ReceiveDamage(float damageAmount)
    {
        health -= damageAmount;

        Die();
    }

    private void Die()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
