using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    gun_Normal,
    gun_DoubleBullet,
    gun_ThreeBullet,
}

public class HeroMainGun : GunBase
{
    public Transform[] firePoint;

    // Update is called once per frame
    public override void Fire()
    {
        for (int i = 0; i < firePoint.Length; i++)
        {
            Instantiate(bullet, firePoint[i].transform.position, firePoint[i].transform.rotation);
        }

        AudioSource.PlayClipAtPoint(bulletMusic, transform.localPosition);
    }
}
