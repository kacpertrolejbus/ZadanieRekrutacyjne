using UnityEngine;

public class RockBigSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float initialSpawnRate = 3f;
    public float minSpawnRate = 1f;
    public float spawnRateDecrease = 0.01f;
    public float difficultyIncreaseInterval = 30f;

    private float currentSpawnRate;
    private float elapsedTime;

    private void OnEnable()
    {
        currentSpawnRate = initialSpawnRate;
        InvokeRepeating(nameof(Spawn), currentSpawnRate, currentSpawnRate);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= difficultyIncreaseInterval)
        {
            IncreaseDifficulty();
            elapsedTime = 0f;
        }
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject rocks = Instantiate(prefab, transform.position, Quaternion.identity);
        
    }

    private void IncreaseDifficulty()
    {
        float newSpawnRate = Mathf.Max(minSpawnRate, currentSpawnRate - spawnRateDecrease);
        if (newSpawnRate < currentSpawnRate)
        {
            currentSpawnRate = newSpawnRate;
            CancelInvoke(nameof(Spawn));
            InvokeRepeating(nameof(Spawn), currentSpawnRate, currentSpawnRate);
        }
    }
}

