using UnityEngine;

public class RedMineralSpawner : MonoBehaviour
{
    private RedNodeHealth health;
    [SerializeField] private GameObject mineralPrefab;

    private void Awake()
    {
        health = GetComponent<RedNodeHealth>();

        health.onMiningOreDestroy += DropMineral;
    }

    private void OnDestroy()
    {
        health.onMiningOreDestroy -= DropMineral;
    }

    private void DropMineral()
    {
        Instantiate(mineralPrefab, transform.position, Quaternion.identity);
    }
}
