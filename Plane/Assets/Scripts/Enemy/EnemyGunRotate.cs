using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunRotate : EnemyGunBase
{
    public Transform firePoint;
    public float angle = 1;
    private float sumAngle = 0;

    public override void Fire()
    {
        GameObject obj = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
        obj.SendMessage("changeDamageByEnemy", enemyType);

        sumAngle += angle;

        firePoint.Rotate(0, 0, angle);
    }
}
