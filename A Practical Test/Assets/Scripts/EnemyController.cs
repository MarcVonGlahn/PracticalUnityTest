using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    private bool _isAlive = true;

    private float _shootingTimer = 0.0f;
    private float _shootIntervall = 0.0f;
    private float _projectileDamage = 0.0f;

    private Vector2 _shootIntervallRange;

    public void InitializeEnemy(float projectileDamage, Vector2 shootIntervallRange)
    {
        _shootIntervallRange = shootIntervallRange;
        _projectileDamage = projectileDamage;

        SetShootIntervall();
    }


    private void Update()
    {
        _shootingTimer += Time.deltaTime;

        if(_shootingTimer > _shootIntervall)
        {
            ShootProjectile();
            SetShootIntervall();
        }
    }

    private void ShootProjectile()
    {
        GameObject newProjectile = Instantiate<GameObject>(projectilePrefab, transform.position, Quaternion.identity);

        newProjectile.GetComponent<ProjectileControl>().Initialize(false, new Vector3(0, 0, -10.0f), _projectileDamage, 10.0f);
    }


    private void SetShootIntervall()
    {
        _shootingTimer = 0.0f;
        _shootIntervall = Random.Range(_shootIntervallRange.x, _shootIntervallRange.y);
    }


    public void KillEnemy()
    {
        Destroy(gameObject);
    }
}
