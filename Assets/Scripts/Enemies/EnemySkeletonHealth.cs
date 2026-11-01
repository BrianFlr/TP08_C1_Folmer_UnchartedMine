using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemySkeletonHealth : MonoBehaviour
{
    public event Action onSkeletonDie;

    [SerializeField] private EnemiesDataSo skeletonData;
    [SerializeField] private Image fillHealthBar;
    [SerializeField] private GameObject enemyDeathEffectPrefab;

    private float health = 0f;

    private void Start()
    {
        health = skeletonData.blueGolemHealth;
    }

    // Función para recibir daño.
    public void ReceiveDamage(float damageAmount)
    {
        health -= damageAmount;
        fillHealthBar.fillAmount = health / skeletonData.blueGolemHealth;

        Die();
    }

    private void Die()
    {
        if (health < 1)
        {
            onSkeletonDie?.Invoke();

            Instantiate(enemyDeathEffectPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
