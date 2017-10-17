using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSideWeapon : MonoBehaviour
{
    public float sideGunTime = 10f;  //三枪存在的时间
    private float resetSideWeaponTime;   //复位三枪时间

    public HeroSideGun gun_Side_Weapon;

    private Animator[] anim;

    private bool isActivate = false;

	// Use this for initialization
	void Start () {
        resetSideWeaponTime = sideGunTime;  //把复位时间设置为三枪存在的时间(这里是10s)
        sideGunTime = 0;          //把三枪存在的时间设为0
        anim = gun_Side_Weapon.GetComponentsInChildren<Animator>(); //获取动画组件
	}
	
	// Update is called once per frame
	void Update () {
        sideGunTime -= Time.deltaTime;   //三枪存在的时间每帧递减

        if (sideGunTime <= 0)  //如果三枪还存在
        {
            if (isActivate)
            {
                isActivate = false;
                gun_Side_Weapon.stopFire();
                
                foreach (Animator child in anim)
                {
                    child.SetBool("Dead", true);
                }

                Invoke("hideSideWeapon", 0.35f);
                //Destroy(gun_Side_Weapon.gameObject, 0.35f);
            }
        }
	}

    void openSideWeapon()  //变为武器加强模式
    {
        gun_Side_Weapon.gameObject.SetActive(true);
        gun_Side_Weapon.openFire();
    }

    void hideSideWeapon()  //变为武器加强模式
    {
        gun_Side_Weapon.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)  //主角碰撞检测代码
    {
        if (other.tag == "Prop")  //如果碰到标签为补给品的物体
        {
            Prop prop = other.GetComponent<Prop>();  //判断补给品的种类
            if (prop.propType == PropType.Side_Weapon)  //如果是三子弹补给
            {
                //print("补给");
                if (!isActivate)
                {
                    isActivate = true;
                    openSideWeapon();
                }
                sideGunTime = resetSideWeaponTime; //设置武器加强时间
                Destroy(other.gameObject);
            }
        }
    }
}
