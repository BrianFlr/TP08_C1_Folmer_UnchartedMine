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
            Instantiate(dynamintePackPrefab, transform.position, Quaternion.identity);
        }
    }

    public void SetInPlaceItemZone(bool state)
    {
        isInPlaceItemZone = state;
    }
}
