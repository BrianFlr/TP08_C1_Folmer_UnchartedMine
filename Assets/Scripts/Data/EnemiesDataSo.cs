using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesData", menuName = "Data/Game/EnemiesData")]

public class EnemiesDataSo : ScriptableObject
{
    [Header("Skeleton")]
    [Range(1, 150)] public float skeletonHealth = 15.0f;
    [Range(1, 10)] public float skeletonSpeed = 2.0f;
    [Range(1, 100)] public float skeletonDamage = 10.0f;

    [Header("Ghost")]
    [Range(1, 150)] public float ghostHealth = 30.0f;
    [Range(1, 10)] public float ghostSpeed = 2.0f;
    [Range(1, 100)] public float ghostDamage = 25.0f;
    [Range(1, 10)] public float ghostAggroRange = 5.0f;
}
