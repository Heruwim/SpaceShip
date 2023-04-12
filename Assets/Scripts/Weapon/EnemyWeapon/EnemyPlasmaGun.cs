using UnityEngine;

public class EnemyPlasmaGun : EnemyWeapon
{
    public override void EnemyShoot(Transform enemyShootPoint)
    {
        Instantiate(Bullet, enemyShootPoint.position, Quaternion.identity);
    }
}
