using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesData", menuName = "Data/Game/EnemiesData")]

public class EnemiesDataSo : ScriptableObject
{
    [Header("Blue Golem")]
    [Range(1, 150)] public float blueGolemHealth = 30.0f;
    [Range(1, 10)] public float blueGolemSpeed = 2.0f;
    [Range(1, 100)] public float blueGolemDamage = 10.0f;

    [Header("Orange Golem")]
    [Range(1, 150)] public float orangeGolemHealth = 30.0f;
    [Range(1, 10)] public float orangeGolemSpeed = 2.0f;
    [Range(1, 100)] public float orangeGolemDamage = 25.0f;
    [Range(1, 10)] public float orangeGolemAggroRange = 5.0f;
}
