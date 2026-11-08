using UnityEngine;

public class PickableMeleeDamage : Pickables
{
    [SerializeField] PickablesDataSo data;
    private float damageToSet = 0f;

    private void Start()
    {
        damageToSet = data.damageToSet;
    }

    public override void Pick()
    {
        GameManager.Instance.SetMeleeDamage(damageToSet);
        Destroy(gameObject);
    }
}
