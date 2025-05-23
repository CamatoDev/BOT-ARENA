using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject healthItemPrefab;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public float spawnInterval = 15f;
    Vector3 range;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 5f, spawnInterval);
    }

    void SpawnItem()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            0f
        );

        range = spawnPos;

        Instantiate(healthItemPrefab, spawnPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, range);
    }
}