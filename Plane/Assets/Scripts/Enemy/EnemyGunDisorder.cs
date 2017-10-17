using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunDisorder : GunBase {
    public Transform firePoint;

    public override void Fire()
    {
        firePoint.Rotate(0, 0, Random.Range(0, 361));

        Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        //初始化一个上面获得的物体，位置为当前脚本所在的物体上的位置，角度为自身角度

        dartleRate = Random.Range(0, 0.04f);
    }
}
