using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSideGun : GunBase
{
    public Transform firePointLeft;
    public Transform firePointRight;

    // Update is called once per frame
    public override void Fire()
    {
        if (GetComponentInParent<HeroMainWeapon>().getWeaponType() == GunType.gun_ThreeBullet)
        {
            firePointLeft.Rotate(0, 0, 8);
            Instantiate(bullet, firePointLeft.transform.position, firePointLeft.transform.rotation);
            
            firePointLeft.Rotate(0, 0, -8);

            firePointRight.Rotate(0, 0, -8);
            Instantiate(bullet, firePointRight.transform.position, firePointRight.transform.rotation);
            firePointRight.Rotate(0, 0, 8);
        }
        else
        {
            Instantiate(bullet, firePointLeft.transform.position, firePointLeft.transform.rotation);

            Instantiate(bullet, firePointRight.transform.position, firePointRight.transform.rotation);
        }

        AudioSource.PlayClipAtPoint(bulletMusic, transform.localPosition);
    }
}
