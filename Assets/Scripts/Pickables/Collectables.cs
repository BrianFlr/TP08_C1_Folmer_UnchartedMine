using System;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.SetCollectablePickedCounter();
        Destroy(gameObject);
    }
}
