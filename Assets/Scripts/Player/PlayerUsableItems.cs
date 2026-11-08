using UnityEngine;

public class PlayerUsableItems : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private GameObject dynamintePackPrefab;

    private bool isInPlaceItemZone = false;

    private void Update()
    {
        if (Input.GetKey(data.placeItem) && isInPlaceItemZone && GameManager.Instance.GetDynamitePackPickedState())
        {
            SpawnDynamitePack();
        }
    }

    private void SpawnDynamitePack()
    {
        Instantiate(dynamintePackPrefab, transform.position, Quaternion.identity);
        GameManager.Instance.SetDynamitePack(false);
    }

    public void SetInPlaceItemZone(bool state)
    {
        isInPlaceItemZone = state;
    }
}
