using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class FallingRock : MonoBehaviour
{
    [Header("Movimento")]
    public float fallSpeed = 4f;

    [Header("Limpeza (evitar acúmulo de objetos fora de tela)")]
    [Tooltip("Distância abaixo da câmera a partir da qual a pedra é destruída")]
    public float destroyBelowCameraOffset = 3f;

    private Rigidbody2D rb;
    private Camera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.down * fallSpeed * Time.fixedDeltaTime);

        if (cam != null)
        {
            float destroyY = cam.transform.position.y - cam.orthographicSize - destroyBelowCameraOffset;
            if (rb.position.y < destroyY)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }

        Destroy(gameObject);
    }
}