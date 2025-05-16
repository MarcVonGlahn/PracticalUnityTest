using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    private bool _isShotByPlayer;
    
    private Vector3 _velocity;

    private float _age;
    private float _lifeTime = 0.0f;
    private float _projectileDamage = 0.0f;

    public bool IsShotByPlayer { get => _isShotByPlayer; }

    private void Start()
    {
        _age = 0.0f;
    }

    public void Initialize(bool isShotByPlayer, Vector3 velocity, float projectileDamage = 0.0f, float lifetime = 5.0f)
    {
        _isShotByPlayer = isShotByPlayer;
        _velocity = velocity;
        _projectileDamage = projectileDamage;

        _lifeTime = lifetime;
    }


    private void Update()
    {
        _age += Time.deltaTime;

        if (_age >= _lifeTime)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += _velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerController>())
        {
            if (_isShotByPlayer)
                return;

            other.gameObject.GetComponentInParent<PlayerController>().TakeDamage(_projectileDamage);

            Destroy(gameObject);
        }
        else if (other.gameObject.GetComponent<EnemyController>())
        {
            if (!_isShotByPlayer)
                return;

            other.gameObject.GetComponent<EnemyController>().KillEnemy();

            Destroy(gameObject);
        }
    }
}
