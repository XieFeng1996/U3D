using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMainWeapon : MonoBehaviour
{
    public float doubleGunTime = 10f;  //双枪存在的时间
    private float resetDoubleWeaponTime;   //复位双枪时间

    public float threeGunTime = 10f;  //三枪存在的时间
    private float resetThreeWeaponTime;   //复位三枪时间

    private GunType weapon = GunType.gun_Normal;   //当前武器的种类(状态)
    public HeroMainGun gun_Normal, gun_DoubleBullet, gun_ThreeBullet;  //获取三种枪

    public AudioClip getPropMusic;

    // Use this for initialization
    void Start()
    {
        resetDoubleWeaponTime = doubleGunTime;  //把复位时间设置为双枪存在的时间(这里是10s)
        doubleGunTime = 0;          //把双枪存在的时间设为0

        resetThreeWeaponTime = threeGunTime;  //把复位时间设置为三枪存在的时间(这里是10s)
        threeGunTime = 0;          //把三枪存在的时间设为0

        gun_Normal.openFire();    //发射子弹
    }

    // Update is called once per frame
    void Update()
    {
        doubleGunTime -= Time.deltaTime;   //双枪存在的时间每帧递减
        threeGunTime -= Time.deltaTime;   //三枪存在的时间每帧递减

        if (threeGunTime > 0)  //如果三枪还存在
        {
            if (weapon != GunType.gun_ThreeBullet)
            {
                changeToThreeWeapon();
            }
        }
        else if (doubleGunTime > 0)  //如果双枪还存在
        {
            if (weapon != GunType.gun_DoubleBullet)
            {
                changeToDoubleWeapon();
            }
        }
        else  //如果三枪或双枪都不存在
        {
            if (weapon != GunType.gun_Normal)
            {
                changeToBesaWeapon();
            }
        }
    }

    public GunType getWeaponType()
    {
        return weapon;
    }

    void changeToDoubleWeapon()  //变为双枪模式
    {
        weapon = GunType.gun_DoubleBullet;
        gun_Normal.stopFire();
        gun_DoubleBullet.openFire();
        gun_ThreeBullet.stopFire();
    }

    void changeToThreeWeapon()  //变为三枪模式
    {
        weapon = GunType.gun_ThreeBullet;
        gun_Normal.stopFire();
        gun_DoubleBullet.stopFire();
        gun_ThreeBullet.openFire();
    }

    void changeToBesaWeapon()  //变为单枪模式
    {
        weapon = GunType.gun_Normal;
        gun_Normal.openFire();
        gun_DoubleBullet.stopFire();
        gun_ThreeBullet.stopFire();
    }

    public void OnTriggerEnter2D(Collider2D other)  //主角碰撞检测代码
    {
        if (other.tag == "Prop")  //如果碰到标签为补给品的物体
        {
            Prop prop = other.GetComponent<Prop>();  //判断补给品的种类
            if (prop.propType == PropType.doubleBullet)  //如果是双枪补给
            {
                doubleGunTime = resetDoubleWeaponTime;
                Destroy(other.gameObject);
            }
            else if (prop.propType == PropType.threeBullet)  //如果是三枪补给
            {
                threeGunTime = resetThreeWeaponTime;
                Destroy(other.gameObject);
            }
            else if (prop.propType == PropType.Shield)  //如果是防护罩
            {
                PropManager._instance.addAShield();
                Destroy(other.gameObject);
            }
            else if (prop.propType == PropType.boom)  //如果是炸弹补给
            {
                PropManager._instance.addAbomb();
                Destroy(other.gameObject);
            }

            AudioSource.PlayClipAtPoint(getPropMusic, transform.localPosition);
        }
    }
}
