using UnityEngine;

[CreateAssetMenu(fileName = "MiningNodesData", menuName = "Data/Game/MiningNodesData")]

public class MiningNodesDataSo : ScriptableObject
{
    [Header("Stats")]
    [Range(1, 100)] public float health = 50.0f;
    [Range(1, 10)] public float statesQuantity = 3.0f;
}
