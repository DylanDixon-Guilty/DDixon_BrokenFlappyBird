using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = .1f;
    public float randomVariable = 1f;
    public Transform wherewewanttheprefabtostart;
    
    private float timer = float.MaxValue;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            DoStuff();
            timer = 0f;
        }
    }

    public void StartSpawning()
    {
        enabled = true;
    }

    void DoStuff()
    {
        float yOffset = Random.Range(-randomVariable, randomVariable);
        Vector3 spawnPosition = wherewewanttheprefabtostart.position + Vector3.up * yOffset;
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
