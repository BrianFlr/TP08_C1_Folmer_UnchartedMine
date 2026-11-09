using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffectsData", menuName = "Data/Audio/SoundEffectsData")]

public class SoundEffectsDataSo : ScriptableObject
{
    [Header("Player Sfx")]
    public AudioClip[] playerWalkSounds;
    public AudioClip[] playerJumpSounds;
    public AudioClip[] playerAttackSounds;
    public AudioClip[] playerHurtSounds;
    public AudioClip[] playerDieSounds;

    [Header("Golems Sfx")]
    public AudioClip[] golemWalkSounds;
    public AudioClip[] golemAttackSounds;
    public AudioClip[] golemHurtSounds;
    public AudioClip[] golemDieSounds;

    [Header("Items Sfx")]
    public AudioClip[] dynamiteLiteSound;
    public AudioClip[] dynamiteExplosionSound;

    [Header("Pickables Sfx")]
    public AudioClip[] spawnSounds;
    public AudioClip[] pickSounds;
}
