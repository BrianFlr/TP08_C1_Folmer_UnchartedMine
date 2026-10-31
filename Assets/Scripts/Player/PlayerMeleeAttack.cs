using System;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public event Action onPlayerAttack;

    [Header("Data")]
    [SerializeField] private PlayerDataSo playerData;
    private Rigidbody2D rb;

    private float attackCooldown = 0f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        attackCooldown = playerData.attackCooldown;
    }

    private void Update()
    {
        if (Time.time > nextAttackTime)
        {
            if (Input.GetMouseButtonDown((int)playerData.meleeAttack))
            {
                PlayerAttack();
            }
        }
    }

    private void PlayerAttack()
    {
        onPlayerAttack?.Invoke();



        nextAttackTime = Time.time + attackCooldown;
    }

}
