using UnityEngine;

public class PickableShield : Pickables
{
    [SerializeField] private PickablesDataSo data;
    [SerializeField] private SoundEffectsDataSo sfxData;

    private float invulnerabilityTime = 0f;

    private void Start()
    {
        invulnerabilityTime = data.invulnerabilityTime;
    }

    public override void Pick()
    {
        GameManager.Instance.ActivatePlayerImmortality(invulnerabilityTime);
        Destroy(gameObject);

        AudioManager.Instance.PlaySfx(sfxData.powerUpPickSounds);
    }
}
