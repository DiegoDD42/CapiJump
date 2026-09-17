using System.Collections;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    [Header("Configurações")]
    public float fallDelay = 1f;      // Tempo total até quebrar
    public float respawnDelay = 3f;   // Tempo para reaparecer

    [Header("Efeito de Piscar")]
    public float flashSpeed = 0.2f;   // Quão rápido pisca (menor = mais rápido)
    public int flashesBeforeFall = 5; // Quantas vezes pisca antes de cair

    private Collider2D platformCollider;
    private SpriteRenderer spriteRenderer;
    private bool isBreaking = false;

    // Cache da cor original para restaurar depois
    private Color originalColor;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreaking) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Verifica se o player está em cima
                if (contact.normal.y < -0.5f)
                {
                    StartCoroutine(BreakAndRespawn());
                    break;
                }
            }
        }
    }

    private IEnumerator BreakAndRespawn()
    {
        isBreaking = true;

        // --- Inicia o Efeito Visual ---
        // Calculamos quanto tempo cada ciclo de pisca/despisca deve durar
        float flashDuration = fallDelay / (flashesBeforeFall * 2);
        StartCoroutine(FlashEffect(flashDuration));
        // ------------------------------

        // Aguarda o tempo total antes de quebrar
        yield return new WaitForSeconds(fallDelay);

        // Desativa colisor e sprite
        platformCollider.enabled = false;
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
            // Restaura a cor caso o efeito de piscar termine com transparência
            spriteRenderer.color = originalColor; 
        }

        // Aguarda o tempo para reaparecer
        yield return new WaitForSeconds(respawnDelay);

        // Reativa colisor e sprite
        platformCollider.enabled = true;
        if (spriteRenderer != null)
            spriteRenderer.enabled = true;

        isBreaking = false;
    }

    // Coroutine que altera a transparência do sprite
    private IEnumerator FlashEffect(float duration)
    {
        bool isVisible = true;

        // Pisca o número de vezes configurado
        for (int i = 0; i < flashesBeforeFall * 2; i++)
        {
            isVisible = !isVisible;
            
            if (spriteRenderer != null)
            {
                // Altera apenas o Alpha (transparência) da cor
                Color color = spriteRenderer.color;
                color.a = isVisible ? 1f : 0.3f; // Alterna entre visível e semi-transparente
                spriteRenderer.color = color;
            }

            yield return new WaitForSeconds(duration);
        }

        // Garante que o sprite fique visível novamente no final do efeito (antes de sumir de vez)
        if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = 1f;
                spriteRenderer.color = color;
            }
    }
}