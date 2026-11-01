using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOrangeGolemHealth : MonoBehaviour
{
    public event Action onOrangeGolemDie;

    [SerializeField] private EnemiesDataSo orangeGolemData;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject enemyDeathEffectPrefab;

    private float health = 0f;

    private void Start()
    {
        health = orangeGolemData.orangeGolemHealth;
    }

    // Función para recibir daño.
    public void ReceiveDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.fillAmount = health / orangeGolemData.orangeGolemHealth;

        Die();
    }

    private void Die()
    {
        if (health < 1)
        {
            onOrangeGolemDie?.Invoke();

            Instantiate(enemyDeathEffectPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
