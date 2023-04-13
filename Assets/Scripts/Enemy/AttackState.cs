using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private float _delay;

    private Animator _animator;
    private float _lastAttackTime;
    private Enemy _enemy;

    private void Start()
    {
        _animator = GetComponent<Animator> ();
        _enemy = GetComponent<Enemy> ();
    }

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            Attack(_enemy);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Enemy enemy)
    {
        _animator.Play("Attack");
        enemy.EnemyShoot();
        
    }
}
