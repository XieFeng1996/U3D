using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyWeapon : MonoBehaviour
{
    public GunBase gun_Around, gun_Fower, gun_Rotate;

    // Use this for initialization
    void Start()
    {
        changeWeapon();
    }

    void changeWeapon()
    {
        if (gamedoing._instance.playerDifficuty == 0)
        {
            changeToAroundWeapon();
        }
        else if (gamedoing._instance.playerDifficuty == 1)
        {
            changeToRotateWeapon();
        }
        else
        {
            changeToFowerWeapon();
        }
    }

    void changeToAroundWeapon()
    {
        gun_Around.openFire();
    }

    void changeToFowerWeapon()
    {
        gun_Fower.openFire();
    }

    void changeToRotateWeapon()
    {
        gun_Rotate.openFire();
    }
}
