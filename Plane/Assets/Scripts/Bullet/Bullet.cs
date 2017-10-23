﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    HeroBullet,
    EnemyBullet,
}

public class Bullet : MonoBehaviour {
    public float speed = 10;
    public BulletType bulletType = BulletType.HeroBullet;

	// Use this for initialization
	void Start () {
        Rigidbody2D bullet2D = GetComponent<Rigidbody2D>();

        if (bulletType == BulletType.HeroBullet)
        {
            bullet2D.velocity = transform.up * speed;
        }
        else
        {
            bullet2D.velocity = transform.up * -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && bombManager._instance.count > 0)
        {
            Destroy(gameObject);
        }
	}

    void OnBecameInvisible()
    {
        //子弹超出屏幕边界后销毁子弹
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)  //每次碰撞自动调用次方法
    {
        if (bulletType == BulletType.HeroBullet)
        {
            if (other.gameObject.tag == "Enemy" && !other.GetComponent<Enemy>().isDead) //如果打中的是敌机
            {
                other.gameObject.SendMessage("Behit");  //则调用敌机身上的Behit 方法
                Destroy(this.gameObject); //如果碰撞到了则销毁此物体
            }
        }
        else
        {
            if (other.gameObject.tag == "Hero" && !other.GetComponent<HeroHealth>().isDead) //如果打中的是敌机
            {
                other.gameObject.SendMessage("Behit");  //则调用敌机身上的Behit 方法
                Destroy(this.gameObject); //如果碰撞到了则销毁此物体
            }
        }

    }
}