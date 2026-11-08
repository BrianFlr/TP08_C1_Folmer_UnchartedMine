using System;
using UnityEngine;

public class PlayerPickablesHandle : MonoBehaviour
{
    public event Action onNewPickaxePick;

    private Sprite pickableSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Pickables pick = other.GetComponent<Pickables>();

        if (pick != null)
        {
            pick.Pick();
        }

        PickableMeleeDamage pickDamage = other.GetComponent<PickableMeleeDamage>();

        if(pickDamage != null)
        {
            SetPickableSprite(other.gameObject);
            onNewPickaxePick?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Pickables pick = other.gameObject.GetComponent<Pickables>();

        if (pick != null)
        {
            pick.Pick();
        }
    }

    private void SetPickableSprite(GameObject other)
    {
        SpriteRenderer sr = other.GetComponentInChildren<SpriteRenderer>();
        pickableSprite = sr.sprite;
    }

    public Sprite GetPickableSprite()
    {
        return pickableSprite;
    }
}
