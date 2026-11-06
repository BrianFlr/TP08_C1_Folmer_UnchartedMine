using UnityEngine;

[CreateAssetMenu(fileName = "ObstaclesData", menuName = "Data/Game/ObstaclesData")]

public class ObstaclesDataSo : ScriptableObject
{
    [Header("Stats")]
    [Range(1, 500)] public float health = 200.0f;
}
