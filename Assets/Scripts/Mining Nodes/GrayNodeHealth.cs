using System;
using UnityEngine;

public class GrayNodeHealth : MiningNodeHealth
{
    public event Action onMiningOreDestroy;

    [SerializeField] private MiningNodesDataSo nodesData;
    [SerializeField] private Sprite spriteMidState;
    [SerializeField] private Sprite spriteFinalState;

    private SpriteRenderer srNode;

    private float statesQuantity = 0f;
    [SerializeField] private float health = 0f;
    [SerializeField] private float equivalentHealth = 0f;

    private void Awake()
    {
        srNode = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        health = nodesData.grayNodeHealth;
        statesQuantity = nodesData.grayStatesQuantity;

        equivalentHealth = (health / statesQuantity);
    }

    // Función para recibir daño.
    public override void ReceiveDamage(float damageAmount)
    {
        health -= damageAmount;

        SpriteChanger();
        DesactiveNode();
    }

    // Función para desactivar el objeto.
    private void DesactiveNode()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);

            onMiningOreDestroy?.Invoke();
        }
    }

    // Función para cambiar el sprite.
    private void SpriteChanger()
    {
        if (health <= equivalentHealth * 2 && health > equivalentHealth)
        {
            srNode.sprite = spriteMidState;
        }
        else if (health <= equivalentHealth)
        {
            srNode.sprite = spriteFinalState;
        }
    }
}
