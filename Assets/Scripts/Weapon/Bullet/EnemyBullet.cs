using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Vector2 _direction;

    private void Start()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        _direction = (player.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }

        else if (other.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);

            Destroy(gameObject);
        }
    }
}
