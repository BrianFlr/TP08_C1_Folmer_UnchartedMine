using UnityEngine;

[CreateAssetMenu(fileName = "MineralsData", menuName = "Data/Game/MineralsData")]

public class MineralsDataSo : ScriptableObject
{
    [Header("Common Minerals")]
    [Range(1, 100)] public float pointsToAddCommon = 5.0f;

    [Header("Rare Minerals")]
    [Range(1, 100)] public float pointsToAddRare = 10.0f;

    [Header("Very Rare Minerals")]
    [Range(1, 100)] public float pointsToAddVeryRare = 15.0f;
}
