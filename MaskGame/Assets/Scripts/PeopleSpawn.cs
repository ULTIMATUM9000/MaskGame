using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawn : MonoBehaviour
{
    [SerializeField]
    private float minSpawnInterval = 1.5f;
    [SerializeField]
    private float maxSpawnInterval = 5.0f;

    private float spawnInterval;
    Vector2 gameBorder;
    float minX, maxX, minY, maxY;

    private bool isSpawning = false;

    private void Start()
    {
        CalculateScreenRestrictions();
    }

    private void Update()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }

    protected void CalculateScreenRestrictions()
    {
        gameBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minX = -gameBorder.x ;
        maxX = gameBorder.x;
        minY = -gameBorder.y;
        maxY = gameBorder.y;
    }

    IEnumerator SpawnCoroutine()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        isSpawning = true;
        SpawnEnemy();
        yield return new WaitForSeconds(spawnInterval);
        isSpawning = false;
    }

    private void SpawnEnemy()
    {
        GameObject enemyObject = ObjectPoolManager.instance.GetPooledObject("People");
        if (enemyObject != null)
        {
            Vector3 spawnPos = Vector3.zero;
            spawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY,maxY));
            enemyObject.transform.position = spawnPos;
            enemyObject.SetActive(true);
        }
    }
}
