using UnityEngine;

[CreateAssetMenu(fileName = "PickablesData", menuName = "Data/Game/PickablesData")]

public class PickablesDataSo : ScriptableObject
{
    [Header("Pickable Points")]
    [Range(1, 100)] public float pointsToAdd = 10.0f;

    [Header("Pickable Health")]
    [Range(1, 100)] public float healthToAdd = 15.0f;

    [Header("Pickable Damage")]
    [Range(1, 100)] public float damageToAdd = 2.0f;
}
