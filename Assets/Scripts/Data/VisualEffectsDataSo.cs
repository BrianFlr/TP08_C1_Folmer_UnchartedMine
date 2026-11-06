using UnityEngine;

[CreateAssetMenu(fileName = "VisualEffectsData", menuName = "Data/Game/VisualEffectsData")]

public class VisualEffectsDataSo : ScriptableObject
{
    [Header("Explosion")]
    [Range(0.1f, 10)] public float explosionEffectDuration = 0.6f;
}
