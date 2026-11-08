using UnityEngine;

[CreateAssetMenu(fileName = "MineralsData", menuName = "Data/Game/MineralsData")]

public class MineralsDataSo : ScriptableObject
{
    [Header("General Stats")]
    [Range(0.1f, 10)] public float noCollisionTime = 0.8f;
    [Range(1, 10)] public float spawnImpulseForce = 5f;

    [Header("Common Minerals")]
    [Range(1, 100)] public float pointsToAddCommon = 5.0f;

    [Header("Rare Minerals")]
    [Range(1, 100)] public float pointsToAddRare = 10.0f;

    [Header("Very Rare Minerals")]
    [Range(1, 100)] public float pointsToAddVeryRare = 15.0f;

    [Header("Ultra Rare Minerals")]
    [Range(1, 100)] public float pointsToAddUltraRare = 25.0f;
}
