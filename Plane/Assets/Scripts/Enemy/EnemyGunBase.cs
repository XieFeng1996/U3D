using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunBase : GunBase
{
    public EnemyType enemyType;

    void Start()
    {
        enemyType = GetComponentInParent<EnemyHealth>().enemyType;

        if (enemyType != EnemyType.bossEnemy)
        {
            fireRate = gamedoing._instance.mobsAttackFrequency;
        }
        else
        {
            fireRate = gamedoing._instance.BossAttackFtrquency;
        }
    }
}
