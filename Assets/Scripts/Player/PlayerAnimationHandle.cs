using UnityEngine;

public class PlayerAnimationHandle : MonoBehaviour
{
    private AnimationChanger changer;
    private PlayerMovement movement;
    private PlayerMeleeAttack attack;
    private Rigidbody2D rb;

    private void Start()
    {
        changer = GetComponent<AnimationChanger>();
        movement = GetComponent<PlayerMovement>();
        attack = GetComponent<PlayerMeleeAttack>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (movement.GetIsGroundState())
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

        if (rb.linearVelocityY != 0 && !movement.GetIsGroundState())
        {
            ChangeAnimationState(PlayerAnimations.Jump);
        }
    }

    private void ChangeAnimationState(PlayerAnimations actualAnimation)
    {
        switch (actualAnimation)
        {
            case PlayerAnimations.Idle:
                changer.changeAnimationState("Miner-Idle");
                break;
            case PlayerAnimations.Walk:
                changer.changeAnimationState("Miner-Walk");
                break;
            case PlayerAnimations.Jump:
                changer.changeAnimationState("Miner-Jump");
                break;
            case PlayerAnimations.Attack:
                changer.changeAnimationState("Miner-Attack");
                break;
            case PlayerAnimations.Dig:
                changer.changeAnimationState("Miner-Dig");
                break;
            case PlayerAnimations.Hurt:
                changer.changeAnimationState("Miner-Hurt");
                break;
            case PlayerAnimations.Die:
                changer.changeAnimationState("Miner-Die");
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
