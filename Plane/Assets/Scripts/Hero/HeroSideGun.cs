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
            //初始化一个上面获得的物体，位置为当前脚本所在的物体上的位置，角度为自身角度

            firePointRight.Rotate(0, 0, -8);
            Instantiate(bullet, firePointRight.transform.position, firePointRight.transform.rotation);
            firePointRight.Rotate(0, 0, 8);
            //初始化一个上面获得的物体，位置为当前脚本所在的物体上的位置，角度为自身角度
        }
        else
        {

            Instantiate(bullet, firePointLeft.transform.position, firePointLeft.transform.rotation);
            //初始化一个上面获得的物体，位置为当前脚本所在的物体上的位置，角度为自身角度

            Instantiate(bullet, firePointRight.transform.position, firePointRight.transform.rotation);
            //初始化一个上面获得的物体，位置为当前脚本所在的物体上的位置，角度为自身角度
        }

        AudioSource.PlayClipAtPoint(bulletMusic, transform.localPosition);
    }
}
