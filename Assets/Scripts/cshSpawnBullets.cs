using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshSpawnBullets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public float minX = -8f;
    public float maxX = 8f;
    public float minZ = -2f;
    public float maxZ = 4f;
    public float interval = 0.5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            SpawnBullet();
            timer = 0f;
        }
    }

    void SpawnBullet()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 10f, Random.Range(minZ, maxZ));
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
    }

}
