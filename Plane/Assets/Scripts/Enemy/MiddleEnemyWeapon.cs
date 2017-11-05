using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEnemyWeapon : MonoBehaviour
{
    public GunBase gun_Normal, gun_Super;
    public bool isFire = false;
    private float moveHeight;

    // Use this for initialization
    void Start()
    {
        moveHeight = Screen.height / 200.0f;
    }

    void Update()
    {
        if (isFire)
            return;

        if (transform.position.y < moveHeight)
        {
            changeWeapon();
            isFire = true;
        }
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
