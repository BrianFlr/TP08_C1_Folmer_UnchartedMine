using UnityEngine;

public class GrayMineralSpawner : MonoBehaviour
{
    private GrayNodeHealth health;
    [SerializeField] private GameObject mineralPrefab;

    private void Awake()
    {
        health = GetComponent<GrayNodeHealth>();

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
