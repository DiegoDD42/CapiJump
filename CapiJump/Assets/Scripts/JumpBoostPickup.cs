using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class JumpBoostPickup : MonoBehaviour
{
    [Header("Configuração do boost")]
    [Tooltip("Multiplicador aplicado sobre a força de pulo normal (ex: 1.8 = +80%)")]
    public float jumpMultiplier = 1.8f;

    [Tooltip("Duração do boost em segundos")]
    public float boostDuration = 5f;

    [Header("Feedback (opcional)")]
    public GameObject collectEffect;
    public AudioClip collectSound;

    private void Reset()
    {
        // Garante que o collider já vem configurado como trigger
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerController player = other.GetComponent<PlayerController>();
        if (player == null)
            return;

        player.ApplyJumpBoost(jumpMultiplier, boostDuration);

        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }

        Destroy(gameObject);
    }
}