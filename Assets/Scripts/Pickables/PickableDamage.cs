using UnityEngine;

public class PickableDamage : Pickables
{
    [SerializeField] PickablesDataSo data;
    private float damageToAdd = 0f;

    private void Start()
    {
        damageToAdd = data.damageToAdd;
    }

    public override void Pick()
    {
        GameManager.Instance.AddBoostDamage(damageToAdd);
        Destroy(gameObject);
    }
}
