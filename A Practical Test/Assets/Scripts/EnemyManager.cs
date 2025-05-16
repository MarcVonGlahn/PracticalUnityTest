using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private SOEnemyAttributes enemyAttributes;
    [SerializeField] private GameObject enemyPrefab;

    private bool _isMovingRight;

    private Vector2 _horizontalMovementRange;

    private Vector3 _startPosition;
    private Vector3 _currentMovement;



    private void Start()
    {
        InitializeManager();
        InitializeEnemies();
    }


    private void InitializeManager()
    {
        _isMovingRight = true;


        _startPosition = new Vector3(
            -(enemyAttributes.XOffset * enemyAttributes.TotalColumns / 2),
            0.0f,
            enemyAttributes.ManagerWorldZOffset);
        transform.position = _startPosition;


        float distanceToEdge = Mathf.Abs(enemyAttributes.WorldHorizontalRange.x - _startPosition.x);
        _horizontalMovementRange = new Vector2(_startPosition.x - distanceToEdge, _startPosition.x + distanceToEdge);

        _currentMovement = new Vector3(enemyAttributes.ManagerHorizontalSpeed, 0, 0);
    }


    private void InitializeEnemies()
    {
        for(int i = 0; i < enemyAttributes.TotalColumns; i++)
        {
            for(int j = 0; j < enemyAttributes.TotalRows; j++)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, transform);

                newEnemy.transform.localPosition = new Vector3(enemyAttributes.XOffset * i + enemyAttributes.XOffset / 2, 0, enemyAttributes.YOffset * j);

                newEnemy.GetComponent<EnemyController>().InitializeEnemy(enemyAttributes.EnemyProjectileDamage ,enemyAttributes.EnemyObjectShootIntervallRange);
            }
        }
    }


    private void Update()
    {
        transform.position += _currentMovement * Time.deltaTime;

        if (transform.position.x < _horizontalMovementRange.x || transform.position.x > _horizontalMovementRange.y)
        {
            ShiftEnemies();
        }
    }


    private void ShiftEnemies()
    {
        _isMovingRight = !_isMovingRight;

        _currentMovement.x = _isMovingRight ? enemyAttributes.ManagerHorizontalSpeed : -(enemyAttributes.ManagerHorizontalSpeed);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, _horizontalMovementRange.x, _horizontalMovementRange.y),
            transform.position.y,
            transform.position.z - enemyAttributes.ManagerVerticalShift);
    }
}
