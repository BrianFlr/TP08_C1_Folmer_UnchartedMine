using System.Collections;
using UnityEngine;

public class PlayerAnimationHandle : MonoBehaviour
{
    private AnimationChanger animatorChanger;
    private PlayerMovement playerMovement;
    private PlayerMeleeAttack playerAttack;
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;

    [SerializeField] private float previousHealth = 0f;
    private bool isHurt = false;
    private bool isDie = false;

    private void Awake()
    {
        animatorChanger = GetComponent<AnimationChanger>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerMeleeAttack>();
        playerHealth = GetComponent<PlayerHealth>();

        rb = GetComponent<Rigidbody2D>();

        playerAttack.onPlayerAttack += PlayerAttackAnimation;
        playerHealth.onPlayerHealthChange += PlayerHurtAnimation;
        playerHealth.onPlayerHealthChange += PlayerDieAnimation;
    }

    private void Start()
    {
        previousHealth = playerHealth.GetMaxHealthValue();
    }

    private void Update()
    {
        PlayerMoveAnimations();
        PlayerJumpOrFallAnimations();
    }

    private void OnDestroy()
    {
        playerAttack.onPlayerAttack -= PlayerAttackAnimation;
        playerHealth.onPlayerHealthChange -= PlayerHurtAnimation;
        playerHealth.onPlayerHealthChange -= PlayerDieAnimation;
    }

    // Animaciones de movimiento.
    private void PlayerMoveAnimations()
    {
        if (playerMovement.GetIsGroundState() && !isHurt && !playerAttack.GetAttackingState() && !isDie)
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
    private void PlayerJumpOrFallAnimations()
    {
        if (rb.linearVelocityY != 0 && !playerMovement.GetIsGroundState())
        {
            ChangeAnimationState(PlayerAnimations.Jump);
        }
    }

    // Animacion de ataque a melee.
    private void PlayerAttackAnimation()
    {
        if (playerAttack.GetAttackingState())
        {
            ChangeAnimationState(PlayerAnimations.Attack);
        }
    }

    // Animación de daño.
    private void PlayerHurtAnimation()
    {
        if (playerHealth.GetHealthValue() < previousHealth)
        {
            StartCoroutine(PlayerHurt());
        }

        previousHealth = playerHealth.GetHealthValue();
    }

    // Animación de muerte.
    private void PlayerDieAnimation()
    {
        if (playerHealth.GetHealthValue() < 0)
        {
            isDie = true;
            ChangeAnimationState(PlayerAnimations.Die);
        }
    }

    // Para que se reproduzca la animación de daño sin ser interrumpida.
    private IEnumerator PlayerHurt()
    {
        isHurt = true;
        ChangeAnimationState(PlayerAnimations.Hurt);

        yield return new WaitForSeconds(0.3f);

        isHurt = false;
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