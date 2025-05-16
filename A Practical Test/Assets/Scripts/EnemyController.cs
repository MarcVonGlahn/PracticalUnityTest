using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 _gridPosition;


    public void InitializeEnemy(int xGridPosition, int yGridPosition)
    {
        _gridPosition = new Vector2(xGridPosition, yGridPosition);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.GetComponent<ProjectileControl>().IsShotByPlayer)
            return;

        Destroy(gameObject);
    }
}
