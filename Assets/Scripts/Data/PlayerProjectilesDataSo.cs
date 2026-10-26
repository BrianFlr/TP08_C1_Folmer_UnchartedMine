using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProjectilesData", menuName = "Data/Game/PlayerProjectilesData")]

public class PlayerProjectilesDataSo : ScriptableObject
{
    [Header("Dagger")]
    [Range(1, 10)] public float daggerSpeed = 5.0f;
    [Range(1, 100)] public float daggerDamage = 5.0f;
    [Range(1, 5)] public float daggerLifeTime = 1.5f;
    [Range(0.1f, 5.0f)] public float daggerThrowRate = 0.5f;
}
