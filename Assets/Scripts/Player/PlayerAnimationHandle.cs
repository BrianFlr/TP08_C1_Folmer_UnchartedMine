using UnityEngine;

public class PlayerAnimationHandle : MonoBehaviour
{
    private AnimationChanger animatorChanger;
    private PlayerMovement movement;
    private PlayerMeleeAttack attack;

    private const string 

    private void Start()
    {
        animatorChanger = GetComponent<AnimationChanger>();
        movement = GetComponent<PlayerMovement>();
        attack = GetComponent<PlayerMeleeAttack>();
    }

    private void Update()
    {
        if (movement != null)
        {

        }
    }
}
