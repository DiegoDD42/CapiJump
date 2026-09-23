using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;

    private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");
    private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IsGroundedHash, playerController.IsGrounded);
        animator.SetBool(IsMovingHash, Mathf.Abs(playerController.MoveInput.x) > 0.01f);

        UpdateFacingDirection();
    }

    private void UpdateFacingDirection()
    {
        if (spriteRenderer == null)
            return;

        float horizontalInput = playerController.MoveInput.x;

        if (horizontalInput > 0.01f)
        {
            // Sprite original olha pra esquerda -> flipX = true olha pra direita
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < -0.01f)
        {
            spriteRenderer.flipX = false;
        }
        // Se horizontalInput for ~0, mantém a direção que já estava
    }
}