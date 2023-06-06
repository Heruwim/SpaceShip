using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private Transform _enemyShootPoint;

    private Player _target;
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    private ParticleSystem _explosion;
    private int _currentHealth;

    public int Reward => _reward;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    private void Awake()
    {
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        _explosion.Stop();
    }

    public void Init(Player target)
    {
        _target = target;
    }
        
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Dying?.Invoke(this);

            gameObject.SetActive(false);
            _currentHealth = _health;
            EnemyStateMachine stateMachine = gameObject.GetComponent<EnemyStateMachine>();
            stateMachine.ResetState();
            _explosion.transform.position = transform.position;
            _explosion.Play();
        }
    }

    public void EnemyShoot()
    {
        _enemyWeapon.EnemyShoot(_enemyShootPoint);
    }   
    
}
