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
    public KeyCode placeItem = KeyCode.E;

    [Header("Stats")]
    [Range (1,150)] public float health = 100.0f;

    [Range(1, 10)] public float speed = 4.0f;

    [Range(1, 10)] public float jumpForce = 9.0f;
    [Range(0.5f, 2f)] public float doubleJumpForceFactorMultiplicator = 0.75f;

    [Range(1, 10)] public float attackDamage = 5.0f;
    [Range(0.1f, 10f)] public float attackCooldown = 0.5f;
    [Range(0.1f, 10f)] public float attackRadius = 0.3f;
    [Range(0.1f, 10f)] public float attackDelayTime = 0.5f;

    public string playerLayerName = "Player";
    public string enemiesLayerName = "Enemies";
    [Range(0.1f, 10f)] public float invulnerabilityTime = 2.0f;

}
