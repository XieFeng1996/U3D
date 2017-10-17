using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Weapon : MonoBehaviour {
    //public float changeGunTime = 1.0f;
    //private float resetChangeWeaponTime;

    public GunBase gun_Normal, gun_Super;

	// Use this for initialization
	void Start () {
        //resetChangeWeaponTime = changeGunTime;  //把复位时间设置为双枪存在的时间(这里是10s)

        //changeToBesaWeapon();
        changeWeapon();
	}
	
	// Update is called once per frame
	void Update () {
        /*changeGunTime -= Time.deltaTime;

        if (changeGunTime <= 0)
        {
            changeWeapon();
        }*/
	}

    void changeWeapon()
    {
        int wepen = Random.Range(0, 2);

        switch (wepen)
        {
            case 0:
                changeToBesaWeapon();
                break;
            case 1:
                changeToSuperWeapon();
                break;
        }

        //changeGunTime = resetChangeWeaponTime;
    }

    void changeToBesaWeapon()
    {
        gun_Normal.openFire();
        gun_Super.stopFire();
    }

    void changeToSuperWeapon()
    {
        gun_Normal.stopFire();
        gun_Super.openFire();
    }
}
