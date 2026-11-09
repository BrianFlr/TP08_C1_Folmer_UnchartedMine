using UnityEngine;

public class PickableHealth : Pickables
{
    [SerializeField] private PickablesDataSo data;
    [SerializeField] private SoundEffectsDataSo sfxData;
    private float healthToAdd = 0f;

    private void Start()
    {
        healthToAdd = data.healthToAdd;
    }

    public override void Pick()
    {
        GameManager.Instance.AddPlayerHealth(healthToAdd);
        Destroy(gameObject);

        AudioManager.Instance.PlaySfx(sfxData.powerUpPickSounds);
    }
}
