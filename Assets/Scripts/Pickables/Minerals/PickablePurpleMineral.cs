using UnityEngine;

public class PickablePurpleMineral : Pickables
{
    [SerializeField] private MineralsDataSo data;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float pointsToAdd = 0f;

    private void OnEnable()
    {
        rb.AddForce(Vector2.up * data.spawnImpulseForce, ForceMode2D.Impulse);
        pointsToAdd = data.pointsToAddUltraRare;
    }

    public override void Pick()
    {
        GameManager.Instance.AddPlayerPoints(pointsToAdd);
        Destroy(gameObject);
    }
}
