using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [Tooltip("Um ou mais prefabs de pedra — um é sorteado a cada spawn")]
    public GameObject[] rockPrefabs;

    [Header("Timing")]
    [Tooltip("Intervalo mínimo entre spawns (segundos)")]
    public float minSpawnInterval = 1.5f;
    [Tooltip("Intervalo máximo entre spawns (segundos)")]
    public float maxSpawnInterval = 4f;

    [Header("Posicionamento")]
    [Tooltip("Altura acima do topo da câmera onde a pedra aparece")]
    public float spawnHeightAboveCamera = 2f;
    [Tooltip("Margem nas bordas laterais pra pedra não nascer colada na borda da tela")]
    public float horizontalPadding = 0.5f;

    private Camera cam;
    private float timer;
    private float nextSpawnTime;

    private void Start()
    {
        cam = Camera.main;
        SetNextSpawnTime();
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnRock();
            timer = 0f;
            SetNextSpawnTime();
        }
    }

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void SpawnRock()
    {
        if (rockPrefabs == null || rockPrefabs.Length == 0 || cam == null)
            return;

        float camHalfWidth = cam.orthographicSize * cam.aspect;
        float minX = cam.transform.position.x - camHalfWidth + horizontalPadding;
        float maxX = cam.transform.position.x + camHalfWidth - horizontalPadding;

        float spawnX = Random.Range(minX, maxX);
        float spawnY = cam.transform.position.y + cam.orthographicSize + spawnHeightAboveCamera;

        GameObject prefab = rockPrefabs[Random.Range(0, rockPrefabs.Length)];
        Instantiate(prefab, new Vector2(spawnX, spawnY), Quaternion.identity);
    }
}