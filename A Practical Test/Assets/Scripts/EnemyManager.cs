using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private SOEnemyAttributes enemyAttributes;
    [SerializeField] private GameObject enemyPrefab;


    private void Start()
    {
        InitializeManager();
        InitializeEnemies();
    }


    private void InitializeManager()
    {
        transform.position = new Vector3(
            -(enemyAttributes.XOffset * enemyAttributes.TotalColumns / 2),
            0.0f,
            enemyAttributes.ManagerWorldZOffset);
    }


    private void InitializeEnemies()
    {
        for(int i = 0; i < enemyAttributes.TotalColumns; i++)
        {
            for(int j = 0; j < enemyAttributes.TotalRows; j++)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, transform);

                newEnemy.transform.localPosition = new Vector3(enemyAttributes.XOffset * i, 0, enemyAttributes.YOffset * j);
            }
        }
    }


    private void Update()
    {
        
    }
}
