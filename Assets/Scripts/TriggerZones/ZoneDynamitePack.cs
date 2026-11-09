using UnityEngine;

public class ZoneDynamitePack : MonoBehaviour
{
    [SerializeField] private GameObject signE;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInZoneChecker(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        signE.SetActive(false);
    }

    private void PlayerInZoneChecker(GameObject other)
    {
        PlayerUsableItems player = other.GetComponent<PlayerUsableItems>();

        if (player != null && GameManager.Instance.GetDynamitePackPickedState())
        {
            player.SetInPlaceItemZone(true);
            signE.SetActive(true);
        }
    }
}
