using UnityEngine;

public class PlayerAnimationHandle : MonoBehaviour
{
    private AnimationChanger animatorChanger;
    private PlayerMovement playerMovement;
    private PlayerMeleeAttack playerAttack;
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;

    private void Start()
    {
        animatorChanger = GetComponent<AnimationChanger>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerMeleeAttack>();
        playerHealth = GetComponent<PlayerHealth>();

        rb = GetComponent<Rigidbody2D>();

        playerHealth.onPlayerHealthChange += PlayerHurt;
    }

    private void Update()
    {
        PlayerMove();
        PlayerJumpOrFall();
        PlayerAttack();
    }

    private void OnDestroy()
    {
        playerHealth.onPlayerHealthChange -= PlayerHurt;
    }

    // Animaciones de movimiento.
    private void PlayerMove()
    {
        if (playerMovement.GetIsGroundState() && !playerAttack.GetAttackingState())
        {
            if (rb.linearVelocityX != 0)
            {
                ChangeAnimationState(PlayerAnimations.Walk);
            }
            else
            {
                ChangeAnimationState(PlayerAnimations.Idle);
            }
        }

    }

    // Animacion de saltar y caer.
    private void PlayerJumpOrFall()
    {
        if (rb.linearVelocityY != 0 && !playerMovement.GetIsGroundState())
        {
            ChangeAnimationState(PlayerAnimations.Jump);
        }
    }

    // Animacion de ataque a melee.
    private void PlayerAttack()
    {
        if (playerAttack.GetAttackingState())
        {
            ChangeAnimationState(PlayerAnimations.Attack);
        }
    }

    // Animación de daño.
    private void PlayerHurt()
    {
        ChangeAnimationState(PlayerAnimations.Hurt);
    }

    private void ChangeAnimationState(PlayerAnimations actualAnimation)
    {
        switch (actualAnimation)
        {
            case PlayerAnimations.Idle:
                animatorChanger.changeAnimationState("Miner-Idle");
                break;
            case PlayerAnimations.Walk:
                animatorChanger.changeAnimationState("Miner-Walk");
                break;
            case PlayerAnimations.Jump:
                animatorChanger.changeAnimationState("Miner-Jump");
                break;
            case PlayerAnimations.Attack:
                animatorChanger.changeAnimationState("Miner-Attack");
                break;
            case PlayerAnimations.Dig:
                animatorChanger.changeAnimationState("Miner-Dig");
                break;
            case PlayerAnimations.Hurt:
                animatorChanger.changeAnimationState("Miner-Hurt");
                break;
            case PlayerAnimations.Die:
                animatorChanger.changeAnimationState("Miner-Die");
                break;
        }
    }
}

public enum PlayerAnimations
{
    Idle,
    Walk,
    Jump,
    Attack,
    Dig,
    Hurt,
    Die
}
