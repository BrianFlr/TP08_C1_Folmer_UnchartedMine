using UnityEngine;

public class PlayerUsableItems : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private GameObject dynamintePackPrefab;

    private void Update()
    {
        if (Input.GetKey(data.placeItem))
        {
            Instantiate(dynamintePackPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
