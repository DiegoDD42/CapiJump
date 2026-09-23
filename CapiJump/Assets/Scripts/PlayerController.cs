using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float moveSpeed = 7f;

    [Header("Pulo")]
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private PlayerControls controls;

    private Vector2 moveInput;
    private bool isGrounded;

    // =========================================================
    // PROPRIEDADES USADAS PELO PLAYER ANIMATOR
    // =========================================================

    /// <summary>
    /// Indica se o player está sobre uma plataforma.
    /// Usado pelo PlayerAnimator para decidir entre Walk e Jump.
    /// </summary>
    public bool IsGrounded => isGrounded;

    /// <summary>
    /// Retorna a direção atual do movimento.
    /// Usado pelo PlayerAnimator para fazer o Flip horizontal.
    /// </summary>
    public Vector2 MoveInput => moveInput;


    // =========================================================
    // POWER-UP DE PULO
    // =========================================================

    private float jumpForceMultiplier = 1f;
    private Coroutine jumpBoostRoutine;


    // =========================================================
    // INICIALIZAÇÃO
    // =========================================================

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        // Movimento
        controls.Player.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
        };

        controls.Player.Move.canceled += ctx =>
        {
            moveInput = Vector2.zero;
        };

        // Pulo
        controls.Player.Jump.performed += ctx =>
        {
            Jump();
        };
    }


    // =========================================================
    // INPUT SYSTEM
    // =========================================================

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    // =========================================================
    // UPDATE
    // =========================================================

    private void Update()
    {
        CheckGround();
    }


    private void FixedUpdate()
    {
        Move();
    }


    // =========================================================
    // MOVIMENTO
    // =========================================================

    private void Move()
    {
        rb.linearVelocity = new Vector2(
            moveInput.x * moveSpeed,
            rb.linearVelocity.y
        );
    }


    // =========================================================
    // PULO
    // =========================================================

    private void Jump()
    {
        if (!isGrounded)
            return;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce * jumpForceMultiplier
        );
        
        AudioManager.Instance?.PlaySFX(SfxId.Jump);
    }


    // =========================================================
    // GROUND CHECK
    // =========================================================

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
        Debug.Log("IsGrounded: " + isGrounded);
    }


    // =========================================================
    // POWER-UP DE PULO
    // =========================================================

    /// <summary>
    /// Aplica um boost temporário na força do pulo.
    /// </summary>
    /// <param name="multiplier">
    /// Multiplicador da força do pulo.
    /// Exemplo: 1.8 = pulo 80% mais forte.
    /// </param>
    /// <param name="duration">
    /// Duração do boost em segundos.
    /// </param>
    public void ApplyJumpBoost(float multiplier, float duration)
    {
        // Se já houver um boost ativo,
        // cancela o anterior para reiniciar a duração.
        if (jumpBoostRoutine != null)
        {
            StopCoroutine(jumpBoostRoutine);
        }

        jumpBoostRoutine = StartCoroutine(
            JumpBoostCoroutine(multiplier, duration)
        );
    }


    private IEnumerator JumpBoostCoroutine(
        float multiplier,
        float duration
    )
    {
        jumpForceMultiplier = multiplier;

        yield return new WaitForSeconds(duration);

        jumpForceMultiplier = 1f;
        jumpBoostRoutine = null;
    }


    // =========================================================
    // DEBUG DO GROUND CHECK
    // =========================================================

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}
