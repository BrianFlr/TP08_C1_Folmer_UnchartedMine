using UnityEngine;

public class ZoneDynamitePackMarker : MonoBehaviour
{
    [SerializeField] private GameObject signE;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInZoneChecker(other.gameObject, true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerInZoneChecker(other.gameObject, false);
    }

    private void PlayerInZoneChecker(GameObject other, bool state)
    {
        PlayerUsableItems player = other.GetComponent<PlayerUsableItems>();

        if (player != null && GameManager.Instance.GetDynamitePackPickedState())
        {
            player.SetInPlaceItemZone(state);
            signE.SetActive(state);
        }
    }
}
