using UnityEngine;

[CreateAssetMenu(fileName = "GameplayData", menuName = "Data/Game/GameplayData")]

public class GameplayDataSo : ScriptableObject
{
    [Range(5, 25)] public float displacementSpeed = 5f;
    [Range(0.1f, 10f)] public float boosterDisplacementSpeed = 0.5f;
}
