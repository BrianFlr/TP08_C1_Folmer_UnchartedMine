using UnityEngine;

public class PlayerAnimationHandle : MonoBehaviour
{
    private PlayerMovement movementScript;
    private PlayerThrowAttack throwAttackScript;
    [SerializeField] private Animator playerAnimator;
    private Rigidbody2D playerRb;

    private bool isGround;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        movementScript = GetComponent<PlayerMovement>();
        throwAttackScript = GetComponent<PlayerThrowAttack>();

        //throwAttackScript.onPlayerAttack += PlayAttackAnimation;
    }

    void Update()
    {
        isGround = movementScript.GetIsGroundState();

        if (isGround)
        {
            playerAnimator.SetBool("Fall", false);
            playerAnimator.SetBool("Ground", isGround);
        }

        if (playerRb.linearVelocityY > 0 && !isGround)
        {
            playerAnimator.SetBool("Jump", true);
            playerAnimator.SetBool("Ground", false);
        }
        else if (playerRb.linearVelocityY < -0.1f && !isGround)
        {
            playerAnimator.SetBool("Jump", false);
            playerAnimator.SetBool("Fall", true);
        }

        if (Mathf.Abs(playerRb.linearVelocityX) > 0 && isGround)
        {
            playerAnimator.SetBool("Run", true);
            playerAnimator.SetBool("Idle", false);
        }
        else
        {
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Idle", true);
        }
    }

    private void OnDestroy()
    {
        //throwAttackScript.onPlayerAttack -= PlayAttackAnimation;
    }

    private void PlayAttackAnimation()
    {
        playerAnimator.SetTrigger("Attack");
    }
}
