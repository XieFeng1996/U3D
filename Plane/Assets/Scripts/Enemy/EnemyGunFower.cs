using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunFower : EnemyGunBase
{
    public Transform firePoint;
    public int fireCount = 8;
    public float bulletAngle = 5.0f;

    private List<GameObject> firePoints = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        float angle = 360.0f / fireCount;

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
        foreach (GameObject obj in firePoints)
        {
            GameObject obj1 = Instantiate(bullet, obj.transform.position, obj.transform.rotation) as GameObject;
            obj1.SendMessage("changeDamageByEnemy", enemyType);
            obj.transform.Rotate(0, 0, bulletAngle);
        }
    }
}
