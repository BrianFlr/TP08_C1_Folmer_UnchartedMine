using UnityEngine;

public class ZoneFallDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ReceiveDamage(playerHealth.GetMaxHealthValue());
        }
    }
}
