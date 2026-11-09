using UnityEngine;

public class PickableGrayMineral : Pickables
{
    [SerializeField] private MineralsDataSo data;
    [SerializeField] private SoundEffectsDataSo sfxData;
    [SerializeField] private Rigidbody2D rb;
    private float pointsToAdd = 0f;

    private void OnEnable()
    {
        rb.AddForce(Vector2.up * data.spawnImpulseForce, ForceMode2D.Impulse);
        pointsToAdd = data.pointsToAddCommon;

        AudioManager.Instance.PlaySfx(sfxData.mineralSpawnSounds);
    }

    public override void Pick()
    {
        GameManager.Instance.AddPlayerPoints(pointsToAdd);
        Destroy(gameObject);

        AudioManager.Instance.PlaySfx(sfxData.mineralPickSounds);
    }
}
