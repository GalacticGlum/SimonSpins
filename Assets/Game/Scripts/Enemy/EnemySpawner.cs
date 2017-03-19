using UnityEngine;
using UnityUtilities.ObjectPool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private float spawnRate = 1f;
    [SerializeField]
    private float spawnRadius = 20f;

    private float nextEnemy = 1;
    private Transform enemyParent;

    // Use this for initialization
    private void Start()
    {
        enemyParent = new GameObject("Enemies").transform;
        enemyParent.SetParent(transform);
    }

    // Update is called once per frame
    private void Update()
    {
        nextEnemy -= Time.deltaTime;
        if (!(nextEnemy <= 0)) return;

        nextEnemy = spawnRate;
        spawnRate *= 0.9f;
        if (spawnRate < 2)
        {
            spawnRate = 2;
        }

        Vector3 offset = Random.onUnitSphere;
        offset.z = 0;
        offset = offset.normalized * spawnRadius;

        GameObject enemy = ObjectPool.Spawn(enemies[Random.Range(0, enemies.Length)], transform.position + offset, Quaternion.identity);
        enemy.transform.SetParent(enemyParent);
    }
}
