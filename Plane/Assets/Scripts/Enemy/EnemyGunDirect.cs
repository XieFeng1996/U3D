using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunDirect : EnemyGunBase
{
    public Transform[] firePoint;

    // Update is called once per frame
    public override void Fire()
    {
        for (int i = 0; i < firePoint.Length; i++)
        {
            GameObject obj = Instantiate(bullet, firePoint[i].transform.position, firePoint[i].transform.rotation) as GameObject;
            obj.SendMessage("changeDamageByEnemy", enemyType);
        }
    }
}
