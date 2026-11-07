using System.Collections;
using UnityEngine;

public class PickableShield : Pickables
{
    [SerializeField] private PickablesDataSo data;

    private float invulnerabilityTime = 0f;

    private void Start()
    {
        invulnerabilityTime = data.invulnerabilityTime;
    }

    public override void Pick()
    {
        GameManager.Instance.ActivatePlayerImmortality(invulnerabilityTime);
        Destroy(gameObject);
    }
}
