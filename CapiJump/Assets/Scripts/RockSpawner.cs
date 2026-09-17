using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [Header("Rock")]
    public GameObject rockPrefab;

    [Header("Spawn")]
    public float spawnRangeX = 8f;
    public float spawnHeight = 10f;

    [Header("Difficulty")]
    public float initialSpawnInterval = 3f;
    public float minimumSpawnInterval = 1f;
    public float difficultyIncreaseTime = 30f;
    public float intervalDecrease = 0.5f;

    private float spawnTimer;
    private float elapsedTime;

    private Transform cameraTransform;

    private void Start()
    {
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnRock();

            spawnTimer = GetCurrentSpawnInterval();
        }
    }

    private float GetCurrentSpawnInterval()
    {
        float difficultyLevel = Mathf.Floor(
            elapsedTime / difficultyIncreaseTime
        );

        float currentInterval =
            initialSpawnInterval -
            (difficultyLevel * intervalDecrease);

        return Mathf.Max(
            currentInterval,
            minimumSpawnInterval
        );
    }

    private void SpawnRock()
    {
        if (cameraTransform == null || rockPrefab == null)
            return;

        float x = cameraTransform.position.x + Random.Range(-spawnRangeX, spawnRangeX);
        float y = cameraTransform.position.y + spawnHeight;

        Vector3 spawnPosition = new Vector3(x, y, 0f);

        Instantiate(
            rockPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}