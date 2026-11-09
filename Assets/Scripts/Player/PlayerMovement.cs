using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private SoundEffectsDataSo sfxData;
    [SerializeField] private LayerMask layerGround;
    private PlayerMeleeAttack playerAttack;

    private Rigidbody2D rb;

    private bool moveLeftPetition = false;
    private bool moveRightPetition = false;
    private bool jumpPetition = false;

    private float playerSpeed = 0f;
    private float playerJumpForce = 0f;
    private float playerDoubleJumpForce = 0f;
    private float doubleJumpFactor = 0f;
    private float rayCastLength = 0.45f;

    private bool isGround = false;
    private bool isJump = false;
    private bool isDoubleJumpActivate = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerMeleeAttack>();
    }

    private void Start()
    {
        playerSpeed = data.speed;
        playerJumpForce = data.jumpForce;
        doubleJumpFactor = data.doubleJumpForceFactorMultiplicator;
    }

    private void Update()
    {
        if (Input.GetKey(data.moveLeft))
        {
            moveLeftPetition = true;
        }

        if (Input.GetKey(data.moveRight))
        {
            moveRightPetition = true;
        }

        if (Input.GetKeyDown(data.jump))
        {
            jumpPetition = true;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCastLength, layerGround);
        isGround = hit.collider != null;

        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        if (!playerAttack.GetAttackingState())
        {
            if (moveLeftPetition)
            {
                MoveLeft();
                moveLeftPetition = false;
            }

            if (moveRightPetition)
            {
                MoveRight();
                moveRightPetition = false;
            }

            if (jumpPetition)
            {
                Jump();
                jumpPetition = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayCastLength);
    }

    private void MoveLeft()
    {
        rb.linearVelocity = new Vector2(-1 * playerSpeed, rb.linearVelocity.y);
        RotatePlayer();
    }

    private void MoveRight()
    {
        rb.linearVelocity = new Vector2(1 * playerSpeed, rb.linearVelocity.y);
        RotatePlayer();
    }

    private void Jump()
    {
        if (isGround)
        {
            rb.linearVelocity = new Vector2(0, 1) * playerJumpForce;

            isJump = true;

            AudioManager.Instance.PlaySfx(sfxData.playerJumpSounds);
        }
        else if (isJump && isDoubleJumpActivate)
        {
            rb.linearVelocity = new Vector2(0, 1) * playerDoubleJumpForce;

            isJump = false;

            AudioManager.Instance.PlaySfx(sfxData.playerJumpSounds);
        }
    }

    public void ActivateDoubleJump()
    {
        playerDoubleJumpForce = playerJumpForce * doubleJumpFactor;
        isDoubleJumpActivate = true;
    }

    private void RotatePlayer()
    {
        if (rb.linearVelocityX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rb.linearVelocityX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public bool GetIsGroundState()
    {
        return isGround;
    }

}
