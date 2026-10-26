
using UnityEngine;

public class PickableSoul : Pickables
{
    [SerializeField] PickablesDataSo data;
    [SerializeField] private float pointsToAdd = 0f;

    private void Start()
    {
        pointsToAdd = data.pointsToAdd;
    }

    public override void Pick()
    {
        GameManager.Instance.AddPlayerPoints(pointsToAdd);
        Destroy(gameObject);
    }
}
