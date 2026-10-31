using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Game/PlayerData")]

public class PlayerDataSo : ScriptableObject
{
    [Header("Controls")]
    public KeyCode jump = KeyCode.Space;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public MouseButton meleeAttack = MouseButton.Left;

    [Header("Stats")]
    [Range (1,150)]public float health = 100.0f;
    [Range(3, 10)] public float speed = 4.0f;
    [Range(3, 10)] public float jumpForce = 8.0f;
    [Range(1, 10)] public float damage = 5.0f;
    [Range(1, 10)] public float attackCooldown = 1.5f;
}
