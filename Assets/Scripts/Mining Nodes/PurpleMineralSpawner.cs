using UnityEngine;

public class PurpleMineralSpawner : MonoBehaviour
{
    private PurpleNodeHealth health;
    [SerializeField] private GameObject mineralPrefab;

    private void Awake()
    {
        health = GetComponent<PurpleNodeHealth>();

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
