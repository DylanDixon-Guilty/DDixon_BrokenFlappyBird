using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject Pipeprefab;
    public float spawnRate;
    public float randomHeight;
    public Transform PipeTransform;
    
    private float timeToSpawnPipe = float.MaxValue;

    void Update()
    {
        timeToSpawnPipe += Time.deltaTime;
        if (timeToSpawnPipe >= spawnRate)
        {
            SpawnPipe();
            timeToSpawnPipe = 0f;
        }
    }

    /// <summary>
    /// Function to see if the pipe should spawn or not
    /// </summary>
    public void StartSpawning()
    {
        enabled = true;
    }

    /// <summary>
    /// Function to spawn pipe after a certain amount of seconds and place it at a random level of elavation.
    /// </summary>
    void SpawnPipe()
    {
        float yOffset = Random.Range(-randomHeight, randomHeight);
        Vector3 spawnPosition = PipeTransform.position + Vector3.up * yOffset;
        Instantiate(Pipeprefab, spawnPosition, Quaternion.identity);
    }
}
