using UnityEngine;

public class PlayerUsableItems : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private GameObject dynamintePackObject;

    private bool isInPlaceItemZone = false;

    private void Update()
    {
        if (Input.GetKey(data.placeItem) && isInPlaceItemZone && GameManager.Instance.GetDynamitePackPickedState())
        {
            dynamintePackObject.SetActive(true);
            dynamintePackObject.transform.position = transform.position;
        }
    }

    public void SetInPlaceItemZone(bool state)
    {
        isInPlaceItemZone = state;
    }
}
