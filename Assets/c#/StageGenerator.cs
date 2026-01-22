using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    [Header("Beginner Platforms (Score < 30)")]
    public GameObject[] earlyPlatforms;   // ← ここに2種類だけ入れる

    [Header("All Platforms (Score >= 30)")]
    public GameObject[] normalPlatforms;  // ← 今までの全部
    public Transform player;

    public float spawnIntervalY = 2.5f;
    public float spawnRangeX = 3f;
    public int keepCount = 12;

    float nextSpawnY;
    Queue<GameObject> platforms = new Queue<GameObject>();

    void Start()
    {
        nextSpawnY = 0f;

        for (int i = 0; i < keepCount; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (player.position.y + 10f > nextSpawnY)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        GameObject prefab = GetRandomPlatform();

        Vector3 pos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            nextSpawnY,
            0f
        );

        GameObject p = Instantiate(prefab, pos, Quaternion.identity);
        platforms.Enqueue(p);

        nextSpawnY += spawnIntervalY;

        if (platforms.Count > keepCount)
        {
            Destroy(platforms.Dequeue());
        }
    }

    GameObject GetRandomPlatform()
    {
        float score = player.position.y;

        // スコア30未満 → 簡単な足場だけ
        if (score < 30f)
        {
            int index = Random.Range(0, earlyPlatforms.Length);
            return earlyPlatforms[index];
        }
        // スコア30以上 → 全種類
        else
        {
            int index = Random.Range(0, normalPlatforms.Length);
            return normalPlatforms[index];
        }
    }
}