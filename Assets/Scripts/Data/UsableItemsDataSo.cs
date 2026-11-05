using UnityEngine;

[CreateAssetMenu(fileName = "UsableItemsData", menuName = "Data/Game/UsableItemsData")]

public class UsableItemsDataSo : ScriptableObject
{
    [Header("Dynamite")]
    [Range(1, 500)] public float dynamitePackDamage = 200f;
    [Range(1, 20)] public float dynamitePackDamageRange = 5.5f;
    [Range(1, 10)] public float dynamitePackTimer = 5f;
}
