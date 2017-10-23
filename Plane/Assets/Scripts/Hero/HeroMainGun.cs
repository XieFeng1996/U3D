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
            //初始化一个上面获得的物体，位置为当前脚本所在的物体上的位置，角度为自身角度
        }

        AudioSource.PlayClipAtPoint(bulletMusic, transform.localPosition);
    }
}
