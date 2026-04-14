using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipePrefab;

    public float spawnRate = 2f;     // Time between spawns
    public float heightOffset = 2f;  // Random height range

    private float timer = 0f;

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    public float spawnX = 10f;

    void SpawnPipe()
    {
        float randomY = Random.Range(-2f, 2f);

        Vector3 spawnPosition = new Vector3(
            spawnX,
            randomY,
            0
        );

        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }

}
