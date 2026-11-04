using UnityEngine;

[CreateAssetMenu(fileName = "PickablesData", menuName = "Data/Game/PickablesData")]

public class PickablesDataSo : ScriptableObject
{
    [Header("Pickable Health")]
    [Range(1, 100)] public float healthToAdd = 15.0f;

    [Header("Pickable Shield")]
    [Range(1, 100)] public float invulnerabilityTime = 5.0f;

    [Header("Pickable Damage")]
    [Range(1, 100)] public float damageToSet = 10.0f;
}
