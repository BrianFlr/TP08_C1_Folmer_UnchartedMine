using UnityEngine;

public class ZoneGameWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            GameManager.Instance.GameWin();
        }
    }
}
