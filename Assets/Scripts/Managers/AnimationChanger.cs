using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    private Animator animator;
    private string currentState;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void changeAnimationState(string newState)
    {
        // Si es la misma animación, no la interrumpo.
        if (currentState == newState) return;
        
        // Ejecutar la animación.
        animator.Play(newState);

        // Reasigno el estado actual.
        currentState = newState;
    }
}
