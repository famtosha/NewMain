using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : InteractebleItem
{
    [SerializeField] GameObject EnemySpawnPoint = null;
    [SerializeField] int EnemyCount = 1;
    [SerializeField] GameObject Enemy = null;

    public override void UseObj(GameObject interacter)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnEnemy();
        Destroy(gameObject);
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < EnemyCount; i++)
        {
            Instantiate(Enemy, EnemySpawnPoint.transform.position, new Quaternion());
        }
    }
}
