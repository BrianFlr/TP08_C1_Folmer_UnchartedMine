using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBlueGolem : EnemiesHealth
{
    public event Action onBlueGolemDie;

    [SerializeField] private EnemiesDataSo blueGolemData;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject enemyDeathEffectPrefab;

    private float health = 0f;

    private void Start()
    {
        health = blueGolemData.orangeGolemHealth;
    }

    public override void ReceiveDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.fillAmount = health / blueGolemData.orangeGolemHealth;

        Die();
    }

    private void Die()
    {
        if (health < 1)
        {
            onBlueGolemDie?.Invoke();

            Instantiate(enemyDeathEffectPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
