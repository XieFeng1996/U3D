using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public GameObject bullet;
    public AudioClip bulletMusic;

    public float startFireTime = 0.2f;  //发射时间
    public float fireRate = 0.2f;  //发射频率
    public int dartleCount = 1;  //连发数
    public float dartleRate = 0;  //连发频率
    private bool isActivate = false;  //武器是否激活

    public virtual void Fire() { }

    IEnumerator startFire()
    {
        yield return new WaitForSeconds(startFireTime);

        while (true)
        {
            for (int i = 0; i < dartleCount; i++)
            {
                Fire();
                yield return new WaitForSeconds(dartleRate);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void openFire()  //开火
    {
        if (!isActivate)
        {
            isActivate = true;
            StartCoroutine("startFire");
        }
    }
    public void stopFire()  //停止开火
    {
        if (isActivate)
        {
            isActivate = false;
            StopCoroutine("startFire");
        }
    }
}
