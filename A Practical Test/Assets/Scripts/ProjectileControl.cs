using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    private bool _isShotByPlayer;
    
    private Vector3 _velocity;

    private float _age;
    private float _lifeTime = 0-0f;

    private void Start()
    {
        _age = 0.0f;
    }

    public void Initialize(bool isShotByPlayer, Vector3 velocity, float lifetime = 5.0f)
    {
        _isShotByPlayer = isShotByPlayer;
        _velocity = velocity;

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
}
