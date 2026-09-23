using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnIncrement = 1f;
    public float spawnNext = 0f;
    public float xLimit;
    public float MaxtimeLife = 4f;

    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60/spawnRatePerMinute;
            spawnRatePerMinute += spawnIncrement;
            float rand = Random.Range(-xLimit, xLimit);
            Vector2 spawnPosition = new Vector2(rand,8f);
            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition,Quaternion.identity);
            Destroy(meteor, MaxtimeLife);
        }
    }
    
}
