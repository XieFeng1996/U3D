using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunFower : GunBase{
    public Transform firePoint;
    public int fireCount = 8;
    //public int bulletCount = 18;
    public float bulletAngle = 5.0f;

    private List<GameObject> firePoints = new List<GameObject>();
    //private GameObject[] firePoints;

    // Use this for initialization
    void Start()
    {
        float angle = 360.0f / fireCount;

        //firePoints = new GameObject[fireCount];

        for (int i = 0; i < fireCount; i++)
        {
            GameObject obj = new GameObject();

            obj.transform.position = firePoint.transform.position;
            obj.transform.Rotate(0, 0, angle * i);

            obj.transform.parent = firePoint.transform;

            firePoints.Add(obj);
        }
    }

    public override void Fire()
    {
        /*for (int i = 0; i < firePoints.Length; i++)
        {
            Instantiate(bullet, firePoints[i].transform.position, firePoints[i].transform.rotation);
            firePoints[i].transform.Rotate(0, 0, bulletAngle);
        }*/

        foreach (GameObject obj in firePoints)
        {
            Instantiate(bullet, obj.transform.position, obj.transform.rotation);
            obj.transform.Rotate(0, 0, bulletAngle);
        }

        /*for (int i = 0; i < bulletCount; i++)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            firePoint.Rotate(0, 0, bulletAngle);
        }*/
    }
}
