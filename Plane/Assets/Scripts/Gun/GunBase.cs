using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public GameObject bullet;
    public AudioClip bulletMusic;

    public float startFireTime = 0.2f; //发射频率
    public float FireRate = 0.2f; //发射频率
    public int dartleCount = 1;
    public float dartleRate = 0;
    private bool isActivate = false;

    // Update is called once per frame
    public virtual void Fire()
    {
        /*for (int i = 0; i < firePoint.Length; i++)
        {
            Instantiate(bullet, firePoint[i].transform.position, firePoint[i].transform.rotation);
            //初始化一个上面获得的物体，位置为当前脚本所在的物体上的位置，角度为自身角度
        }*/
    }

    IEnumerator startFire()
    {
        yield return new WaitForSeconds(startFireTime);

        //Fire();

        while (true)
        {
            for (int i = 0; i < dartleCount; i++)
            {
                Fire();
                yield return new WaitForSeconds(dartleRate);
            }
            yield return new WaitForSeconds(FireRate);
        }
    }

    public void openFire()
    {
        if (!isActivate)
        {
            isActivate = true;
            //InvokeRepeating("Fire", 0.2f, FireRate);
            StartCoroutine("startFire");
            //1s 之后 每隔 rate(0.2s)  调用一次 Fire 方法
        }
    }
    public void stopFire()  //停止开火
    {
        if (isActivate)
        {
            isActivate = false;
            //CancelInvoke("Fire"); //取消循环调用Fire方法
            StopCoroutine("startFire");
        }
    }
}
