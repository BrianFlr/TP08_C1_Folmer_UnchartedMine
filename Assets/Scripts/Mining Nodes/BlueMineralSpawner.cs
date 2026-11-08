using UnityEngine;

public class BlueMineralSpawner : MonoBehaviour
{
    private BlueNodeHealth health;
    [SerializeField] private GameObject mineralPrefab;

    private void Awake()
    {
        health = GetComponent<BlueNodeHealth>();

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
