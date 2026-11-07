using System.Collections;
using UnityEngine;

public class PlayerImmortality : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    private int playerLayer;
    private int enemiesLayer;

    private float invulnerabilityTime = 0f;

    private void Start()
    {
        invulnerabilityTime = data.invulnerabilityTime;

        playerLayer = LayerMask.NameToLayer(data.playerLayerName);
        enemiesLayer = LayerMask.NameToLayer(data.enemiesLayerName);
    }

    public void ActivateImmortality(float invulnerabilityTime)
    {
        StartCoroutine(Immortality(invulnerabilityTime));
    }

    private IEnumerator Immortality(float time)
    {
        Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, true);

        yield return new WaitForSeconds(time);
        
        Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, false);
    }
}
