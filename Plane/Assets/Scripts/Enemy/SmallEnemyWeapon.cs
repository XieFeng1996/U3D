using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyWeapon : MonoBehaviour
{
    public GunBase gun_Normal;
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
            gun_Normal.openFire();
            isFire = true;
        }
    }
}
