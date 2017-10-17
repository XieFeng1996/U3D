using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Weapon : MonoBehaviour {
    //public float changeGunTime = 1.0f;
    //private float resetChangeWeaponTime;

    public GunBase gun_Normal, gun_Scatter, gun_Super, gun_Fower, gun_Rotate, gun_Disorder;

    // Use this for initialization
    void Start()
    {
        //resetChangeWeaponTime = changeGunTime;  //把复位时间设置为双枪存在的时间(这里是10s)

        //changeToBesaWeapon();
        changeWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        /*changeGunTime -= Time.deltaTime;

        if (changeGunTime <= 0)
        {
            changeWeapon();
        }*/
    }

    void changeWeapon()
    {
        int wepen = Random.Range(5, 6);

        switch (wepen)
        {
            case 0:
                changeToBesaWeapon();
                break;
            case 1:
                changeToScatterWeapon();
                break;
            case 2:
                changeToSpuerWeapon();
                break;
            case 3:
                changeToFowerWeapon();
                break;
            case 4:
                changeToRotateWeapon();
                break;
            case 5:
                changeToDisorderWeapon();
                break;
            default:
                break;
        }

        //changeGunTime = resetChangeWeaponTime;
    }

    void changeToBesaWeapon()
    {
        gun_Normal.openFire();
        gun_Scatter.stopFire();
        gun_Super.stopFire();
        gun_Fower.stopFire();
        gun_Rotate.stopFire();
        gun_Disorder.stopFire();
    }

    void changeToScatterWeapon()
    {
        gun_Normal.stopFire();
        gun_Scatter.openFire();
        gun_Super.stopFire();
        gun_Fower.stopFire();
        gun_Rotate.stopFire();
        gun_Disorder.stopFire();
    }

    void changeToSpuerWeapon()
    {
        gun_Normal.stopFire();
        gun_Scatter.stopFire();
        gun_Super.openFire();
        gun_Fower.stopFire();
        gun_Rotate.stopFire();
        gun_Disorder.stopFire();
    }

    void changeToFowerWeapon()
    {
        gun_Normal.stopFire();
        gun_Scatter.stopFire();
        gun_Super.stopFire();
        gun_Fower.openFire();
        gun_Rotate.stopFire();
        gun_Disorder.stopFire();
    }

    void changeToRotateWeapon()
    {
        gun_Normal.stopFire();
        gun_Scatter.stopFire();
        gun_Super.stopFire();
        gun_Fower.stopFire();
        gun_Rotate.openFire();
        gun_Disorder.stopFire();
    }

    void changeToDisorderWeapon()
    {
        gun_Normal.stopFire();
        gun_Scatter.stopFire();
        gun_Super.stopFire();
        gun_Fower.stopFire();
        gun_Rotate.stopFire();
        gun_Disorder.openFire();
    }
}
