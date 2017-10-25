using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyWeapon : MonoBehaviour
{
    public GunBase gun_Normal;

    // Use this for initialization
    void Start()
    {
        gun_Normal.openFire();
    }
}
