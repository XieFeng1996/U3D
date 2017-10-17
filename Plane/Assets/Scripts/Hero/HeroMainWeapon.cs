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
    public HeroMainGun gun_Normal, gun_DoubleBullet, gun_ThreeBullet;  // 用来获取三个发射子弹的位置的变量

	// Use this for initialization
	void Start () {
        resetDoubleWeaponTime = doubleGunTime;  //把复位时间设置为双枪存在的时间(这里是10s)
        doubleGunTime = 0;          //把双枪存在的时间设为0

        resetThreeWeaponTime = threeGunTime;  //把复位时间设置为三枪存在的时间(这里是10s)
        threeGunTime = 0;          //把三枪存在的时间设为0

        gun_Normal.openFire();    //调用Shoot中的OpenFire方法，发射子弹
	}
	
	// Update is called once per frame
	void Update () {
        doubleGunTime -= Time.deltaTime;   //双枪存在的时间每帧递减
        threeGunTime -= Time.deltaTime;   //三枪存在的时间每帧递减
        
        if (threeGunTime > 0)  //如果三枪还存在
        {
            if (weapon != GunType.gun_ThreeBullet)  //如果当前武器种类只有1个或2个
            {
                changeToThreeWeapon();
            }
        }
        else if (doubleGunTime > 0)  //如果双枪还存在
        {
            if (weapon != GunType.gun_DoubleBullet)  //如果当前武器种类只有1个
            {
                changeToDoubleWeapon();
            }
        }
        else  //如果三枪或双枪都不存在
        {
            if (weapon != GunType.gun_Normal)  //当前武器状态为2种
            {
                changeToBesaWeapon();
            }
        }
	}

    public GunType getWeaponType()
    {
        return weapon;
    }

    void changeToDoubleWeapon()  //变为武器加强模式
    {
        weapon = GunType.gun_DoubleBullet;  //武器数量设为2个
        gun_Normal.stopFire();
        gun_DoubleBullet.openFire();  //打开发射子弹
        gun_ThreeBullet.stopFire(); //右边停止发射
    }

    void changeToThreeWeapon()  //变为武器加强模式
    {
        weapon = GunType.gun_ThreeBullet;  //武器数量设为2个
        gun_Normal.stopFire();
        gun_DoubleBullet.stopFire();
        gun_ThreeBullet.openFire(); //打开发射子弹
    }

    void changeToBesaWeapon()   //变为基础模式
    {
        weapon = GunType.gun_Normal;   //武器数量设为1
        gun_Normal.openFire();
        gun_DoubleBullet.stopFire();  //左边停止发射
        gun_ThreeBullet.stopFire(); //右边停止发射
    }

    public void OnTriggerEnter2D(Collider2D other)  //主角碰撞检测代码
    {
        if (other.tag == "Prop")  //如果碰到标签为补给品的物体
        {
            Prop prop = other.GetComponent<Prop>();  //判断补给品的种类
            if (prop.propType == PropType.doubleBullet)  //如果是双子弹补给
            {
                //print("补给");
                doubleGunTime = resetDoubleWeaponTime; //设置武器加强时间
                Destroy(other.gameObject);
            }
            else if (prop.propType == PropType.threeBullet)  //如果是三子弹补给
            {
                //print("补给");
                threeGunTime = resetThreeWeaponTime; //设置武器加强时间
                Destroy(other.gameObject);
            }
            else if (prop.propType == PropType.boom)  //炸弹
            {
                //print("炸弹");                
                bombManager._instance.addAbomb();
                Destroy(other.gameObject);
            }
        }
    }
}
