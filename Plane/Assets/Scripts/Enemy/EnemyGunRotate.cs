using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunRotate : GunBase{

    public Transform firePoint;

    public float angle = 1;

    private float sumAngle = 0;

    public override void Fire()
    {

        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);

        sumAngle += angle;

        /*if (sumAngle >= 360)
        {
            firePoint.Rotate(0, 0, angle / 2);
        }*/

        firePoint.Rotate(0, 0, angle);
    }
}
