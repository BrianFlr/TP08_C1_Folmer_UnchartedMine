using UnityEngine;

[CreateAssetMenu(fileName = "MiningNodesData", menuName = "Data/Game/MiningNodesData")]

public class MiningNodesDataSo : ScriptableObject
{
    [Header("Gray Mining Node")]
    [Range(1, 100)] public float grayNodeHealth = 15.0f;
    [Range(1, 10)] public float grayStatesQuantity = 3.0f;

    [Header("Blue Mining Node")]
    [Range(1, 100)] public float blueNodeHealth = 25.0f;
    [Range(1, 10)] public float blueStatesQuantity = 3.0f;

    [Header("Red Mining Node")]
    [Range(1, 100)] public float redNodeHealth = 30.0f;
    [Range(1, 10)] public float redStatesQuantity = 3.0f;

    [Header("Purple Mining Node")]
    [Range(1, 100)] public float purpleNodeHealth = 45.0f;
    [Range(1, 10)] public float purpleStatesQuantity = 3.0f;

}
