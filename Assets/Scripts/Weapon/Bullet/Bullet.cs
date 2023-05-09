using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _impactEffect;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
                        
            Destroy(gameObject);
        }
    }
    

}
