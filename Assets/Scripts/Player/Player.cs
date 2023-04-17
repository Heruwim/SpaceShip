using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _currentWeapon.Shoot(_shootPoint);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }

}
