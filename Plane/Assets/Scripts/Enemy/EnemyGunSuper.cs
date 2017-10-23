using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunSuper : GunBase{
    public Transform firePoint;
    public int bulletCount = 18;
    private float bulletAngle;

    void Start()
    {
        bulletAngle = 360.0f / bulletCount;
    }

    public override void Fire()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            firePoint.Rotate(0, 0, bulletAngle);
        }
    }
}
