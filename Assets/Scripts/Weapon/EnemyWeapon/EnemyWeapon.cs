using UnityEngine;

public abstract class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] protected EnemyBullet Bullet;
    public abstract void EnemyShoot(Transform enemyShootPoint);
}
