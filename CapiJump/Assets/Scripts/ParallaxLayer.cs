using UnityEngine;

/// <summary>
/// Faz uma camada de background se mover mais devagar (ou mais rápido)
/// que a câmera, criando efeito de profundidade (parallax).
///
/// Setup no Unity:
/// - Adicionar este script em cada uma das 6 camadas de background.
/// - Ajustar "Parallax Factor" por camada:
///   0.0 = totalmente parada (fundo infinitamente distante)
///   perto de 0 (ex: 0.1-0.3) = camadas mais distantes (céu, montanhas ao fundo)
///   perto de 1 (ex: 0.7-0.9) = camadas mais próximas (arbustos, chão)
///   1.0 = se move junto com a câmera (sem efeito de parallax)
/// </summary>
public class ParallaxLayer : MonoBehaviour
{
    [Header("Intensidade do parallax")]
    [Tooltip("0 = camada parada / 1 = acompanha a câmera 100%")]
    [Range(0f, 1f)]
    public float parallaxFactorY = 0.5f;

    [Range(0f, 1f)]
    public float parallaxFactorX = 0f;

    private Transform cam;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cam = Camera.main.transform;
        lastCameraPosition = cam.position;
    }

    private void LateUpdate()
    {
        Vector3 delta = cam.position - lastCameraPosition;

        transform.position += new Vector3(
            delta.x * parallaxFactorX,
            delta.y * parallaxFactorY,
            0f
        );

        lastCameraPosition = cam.position;
    }
}