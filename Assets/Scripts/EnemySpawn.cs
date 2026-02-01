using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Перетащите сюда префаб врага
    public Transform player;       // Перетащите сюда игрока
    public float minDistance = 5f; // Минимальный радиус появления
    public float maxDistance = 10f;// Максимальный радиус появления
    public float spawnInterval = 2f; // Интервал появления (сек)

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // Генерируем случайное направление и расстояние
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minDistance, maxDistance);
        
        Vector3 spawnPosition = player.position + (Vector3)(randomDirection * randomDistance);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
