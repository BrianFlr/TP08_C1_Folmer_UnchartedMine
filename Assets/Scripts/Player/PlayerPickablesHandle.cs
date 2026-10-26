using UnityEngine;

public class PlayerPickablesHandle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Pickables pick = other.GetComponent<Pickables>();

        if (pick != null)
        {
            pick.Pick();
        }
    }
}
