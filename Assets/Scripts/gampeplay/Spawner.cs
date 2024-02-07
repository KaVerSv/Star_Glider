using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRangeXMin = -100f;
    public float spawnRangeXMax = 100f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        float spawnX = Random.Range(spawnRangeXMin, spawnRangeXMax);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 110f);
        Quaternion spawnRotation = Quaternion.Euler(0f, 180f, 0f);  // Dodaj tê liniê, aby obróciæ o 180 stopni w osi Y

        Instantiate(enemyPrefab, spawnPosition, spawnRotation);
    }
}