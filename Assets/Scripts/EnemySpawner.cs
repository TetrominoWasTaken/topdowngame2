using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 screenBounds;
    public GameObject spawnParticles;
    public GameObject[] enemyPool;
    public float buffer;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine("spawnEnemies");
    }

    void Update()
    {

    }

    IEnumerator spawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Vector3 ranSpawn = new Vector3(Random.Range(-screenBounds.x + buffer, screenBounds.x - buffer), Random.Range(-screenBounds.y + buffer, screenBounds.x - buffer), 0);
            GameObject particle = Instantiate(spawnParticles, ranSpawn, Quaternion.identity);
            yield return new WaitForSeconds(2);
            Destroy(particle);
            Instantiate(enemyPool[Random.Range(0, enemyPool.Length)], ranSpawn, Quaternion.identity);
        }
    }
}
