using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Scriptable Objects/EnemyAttributes")]
public class SOEnemyAttributes : ScriptableObject
{
    [Header("Manager Attributes")]
    [SerializeField] private float managerWorldZOffset = 40.0f;
    [SerializeField] private float managerHorizontalSpeed = 5.0f;
    [SerializeField] private float managerVerticalShift = 5.0f;
    [SerializeField] private Vector2 worldHorizontalRange = new Vector2(-80.0f, 80.0f);

    [Header("Enemy Spawning Attributes")]
    [SerializeField] private int totalRows = 4;
    [SerializeField] private int totalColumns = 8;
    [Space]
    [SerializeField] private float xOffset = 20.0f;
    [SerializeField] private float yOffset = 10.0f;
    [Space]
    [SerializeField] private Vector2 enemyObjectShootIntervallRange = new Vector2(2.0f, 10.0f);
    [SerializeField] private float enemyProjectileDamage = 10.0f;


    public float ManagerWorldZOffset { get => managerWorldZOffset; }
    public float ManagerHorizontalSpeed { get => managerHorizontalSpeed; }
    public float ManagerVerticalShift { get => managerVerticalShift; }
    public Vector2 WorldHorizontalRange { get => worldHorizontalRange; }


    public int TotalRows { get => totalRows; }
    public int TotalColumns { get => totalColumns; }

    public float XOffset { get => xOffset; }
    public float YOffset { get => yOffset; }

    public Vector2 EnemyObjectShootIntervallRange { get => enemyObjectShootIntervallRange; }
    public float EnemyProjectileDamage { get => enemyProjectileDamage; }
}