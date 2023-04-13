using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private Transform _enemyShootPoint;

    [SerializeField] private Player _target;

    public Player Target => _target;

    public event UnityAction Dying;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
    }
    
    public void EnemyShoot()
    {
        _enemyWeapon.EnemyShoot(_enemyShootPoint);
    }
    
}
