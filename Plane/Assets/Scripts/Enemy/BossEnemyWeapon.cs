using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyWeapon : MonoBehaviour
{
    public GunBase gun_Around, gun_Fower, gun_Rotate;
    public bool isFire = false;
    private float bossMoveHeight;

    // Use this for initialization
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;//获取当前飞机高度
        bossMoveHeight = Screen.height / 200.0f - spriteHeight / 2.0f;
    }

    void Update()
    {
        if (isFire)
            return;

        if (transform.position.y < bossMoveHeight)
        {
            changeWeapon();
            isFire = true;
        }
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
