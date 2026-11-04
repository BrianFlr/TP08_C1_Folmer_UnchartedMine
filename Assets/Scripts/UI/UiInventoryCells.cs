using UnityEngine;
using UnityEngine.UI;

public class UiInventoryCells : MonoBehaviour
{
    [SerializeField] private PlayerPickablesHandle playerPickablesHandle;
    [SerializeField] private Image pickaxeIcon;

    private void Awake()
    {
        playerPickablesHandle.onNewPickaxePick += ChangePickaxeIcon;
    }

    private void OnDestroy()
    {
        playerPickablesHandle.onNewPickaxePick -= ChangePickaxeIcon;
    }

    private void ChangePickaxeIcon()
    {
        pickaxeIcon.sprite = playerPickablesHandle.GetPickableSprite();
    }
}
