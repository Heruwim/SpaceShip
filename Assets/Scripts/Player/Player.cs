using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private AudioSource _shootSound;

    [SerializeField] private Menu _menu169;
    [SerializeField] private Menu _menu189;
    [SerializeField] private GameObject _gameOverPanel169;
    [SerializeField] private GameObject _gameOverPanel189;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }
    public int Score { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int> ScoreChanged;


    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _currentWeapon.Shoot(_shootPoint);
        _shootSound.Play();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
        if (_currentHealth <= 0)
        {
            _explosion.transform.position = transform.position;
            _explosion.Play();
            _explosion.GetComponentInChildren<AudioSource>().Play();
            Die();
        }
    }

    public void Die()
    {
        if (IsAspectRatio16_9())
        {
            _menu169.OpenPanel(_gameOverPanel169);
        }
        else
        {
            _menu189.OpenPanel(_gameOverPanel189);
        }
        Destroy(gameObject);
    }

    public void AddMoney(int reward)
    {
        Money += reward;
        MoneyChanged?.Invoke(Money);
    }
    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void AddScore(int score)
    {
        Score += score;
        ScoreChanged?.Invoke(Score);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    private bool IsAspectRatio16_9()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        return Mathf.Approximately(aspectRatio, 16f / 9f);
    }
}
