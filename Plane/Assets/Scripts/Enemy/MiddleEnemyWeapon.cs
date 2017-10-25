using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemyWeapon : MonoBehaviour
{

    public GunBase gun_Normal, gun_Super;

    // Use this for initialization
    void Start()
    {
        changeWeapon();
    }

    void changeWeapon()
    {
        if (gamedoing._instance.playerDifficuty == 0)
        {
            changeToNormalWeapon();
        }
        else
        {
            changeToSuperWeapon();
        }
    }

    void changeToNormalWeapon()
    {
        gun_Normal.openFire();
    }

    void changeToSuperWeapon()
    {
        gun_Super.openFire();
    }
}
