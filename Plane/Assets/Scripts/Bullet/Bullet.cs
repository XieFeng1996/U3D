using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    HeroBullet,
    EnemyBullet,
}

public class Bullet : MonoBehaviour {
    public float speed = 10;
    private int damage;
    public BulletType bulletType = BulletType.HeroBullet;

	// Use this for initialization
	void Start () {
        Rigidbody2D bullet2D = GetComponent<Rigidbody2D>();

        if (bulletType == BulletType.HeroBullet)
        {
            bullet2D.velocity = transform.up * speed;
            damage = gamedoing._instance.playerAirHurt;
        }
        else
        {
            bullet2D.velocity = transform.up * -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && PropManager._instance.boomCount > 0)
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
            if (other.gameObject.tag == "Enemy" && !other.GetComponent<EnemyHealth>().isDead) //如果打中的是敌机
            {
                other.gameObject.SendMessage("Behit",damage);  //则调用敌机身上的Behit 方法
                Destroy(this.gameObject); //如果碰撞到了则销毁此物体
            }
        }
        else
        {
            if (other.gameObject.tag == "Shield")
            {
                if (other.gameObject.activeSelf == true)
                {
                    other.gameObject.transform.parent.SendMessage("Behit", 1);
                    Destroy(this.gameObject); //如果碰撞到了则销毁此物体
                }
            }
            else if (other.gameObject.tag == "Hero" && !other.GetComponent<HeroHealth>().isDead) //如果打中的是玩家
            {
                other.gameObject.SendMessage("Behit", damage);  //则调用玩家身上的Behit 方法
                Destroy(this.gameObject); //如果碰撞到了则销毁此物体
            }
        }

    }

    void changeDamageByEnemy(EnemyType enemyType)
    {
        if (enemyType == EnemyType.smallEnemy)
        {
            damage = gamedoing._instance.mobsHurt1;
        }
        else if (enemyType == EnemyType.middleEnemy)
        {
            damage = gamedoing._instance.mobsHurt2;
        }
        else if (enemyType == EnemyType.bossEnemy)
        {
            damage = gamedoing._instance.mobsHurt3;
        }
    }
}
