using UnityEngine;

public class EnemyPickableDrop : MonoBehaviour
{
    private EnemyHealthOrangeGolem enemyOrangeGolemHealth;

    [Header("Pickables Array")]
    [SerializeField] private GameObject[] pickables;
    private float randomValue = 0f;
    private int idPickable = 0;

    private void Awake()
    {
        enemyOrangeGolemHealth = GetComponent<EnemyHealthOrangeGolem>();

        if(enemyOrangeGolemHealth != null)
        {
            enemyOrangeGolemHealth.onOrangeGolemDie += SpawnPickable;
        }
    }

    private void OnDestroy()
    {

        if (enemyOrangeGolemHealth != null)
        {
            enemyOrangeGolemHealth.onOrangeGolemDie -= SpawnPickable;
        }
    }

    // Funcion para spawnear los power ups
    private void SpawnPickable()
    {
        randomValue = Random.Range(0f, 100.0f);

        if(randomValue <= 50f)
        {
            idPickable = 0;
        }
        else
        {
            idPickable = 1;
        }

        GameObject pickable = pickables[idPickable];

        // Instancio el objeto en la posición del enemigo.
        Instantiate(pickable, transform.position, Quaternion.identity);
    }
}
