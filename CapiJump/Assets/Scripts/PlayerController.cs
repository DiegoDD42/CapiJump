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

    // --- Suporte a power-up de pulo (mola) ---
    private float jumpForceMultiplier = 1f;
    private Coroutine jumpBoostRoutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        controls.Player.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
        };

        controls.Player.Move.canceled += ctx =>
        {
            moveInput = Vector2.zero;
        };

        controls.Player.Jump.performed += ctx =>
        {
            Jump();
        };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        CheckGround();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(
            moveInput.x * moveSpeed,
            rb.linearVelocity.y
        );
    }

    private void Jump()
    {
        if (!isGrounded)
            return;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce * jumpForceMultiplier
        );
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }


    public void ApplyJumpBoost(float multiplier, float duration)
    {
        // Se já existe um boost ativo, cancela pra reiniciar a duração
        // (evita que um boost antigo "expire" por cima de um novo)
        if (jumpBoostRoutine != null)
        {
            StopCoroutine(jumpBoostRoutine);
        }

        jumpBoostRoutine = StartCoroutine(JumpBoostCoroutine(multiplier, duration));
    }

    private IEnumerator JumpBoostCoroutine(float multiplier, float duration)
    {
        jumpForceMultiplier = multiplier;

        yield return new WaitForSeconds(duration);

        jumpForceMultiplier = 1f;
        jumpBoostRoutine = null;
    }

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