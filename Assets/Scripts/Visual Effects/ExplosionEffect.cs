using System.Collections;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private VisualEffectsDataSo data;

    private float effectDuration = 0f;

    private void OnEnable()
    {
        effectDuration = data.explosionEffectDuration;
        StartCoroutine(DestroyEffect());
    }

    private IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(effectDuration);
        Destroy(gameObject);
    }
}
