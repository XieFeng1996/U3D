using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType  //飞机的枚举类型
{
    smallEnemy,  //小型飞机
    middleEnemy, //中型飞机
    bigEnemy,    //大型飞机
}

public class Enemy : MonoBehaviour {
    public float life;
    public float speed;
    public int score;
    public bool isDead = false;
    public AudioClip destoryMusic;

    Animator anim;  //存放动画组件

    public EnemyType planeType = EnemyType.smallEnemy;  //默认是小飞机

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); //获取动画组件
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && bombManager._instance.count > 0)
        {
            life = -1;
            Behit();
            //如果按下了空格键，并且炸弹数目大于0，则把敌人的生命设为-1，全部执行爆炸动画    
        }
    }

    void Behit()   //被击中时从子弹发过来的消息调用的方法
    {
        if (isDead)
            return;

        life--;  //生命值减1

        if (life <= 0)
        {
            isDead = true;
            anim.SetBool("Dead", true);   //开始播放爆炸动画
            AudioSource.PlayClipAtPoint(destoryMusic, transform.localPosition);
            GameMananger._instance.addScore(score); 
        }
        else
        {
            anim.SetBool("Hited", true);   //开始播放爆炸动画
        }
    }

    void Dead()
    {
        Destroy(this.gameObject);

        GetComponent<EnemyPropsDrop>().PropDrop();
    }

    void Hited()
    {
        anim.SetBool("Hited", false);
    }

    void OnBecameInvisible()
    {
        //飞机超出屏幕边界后销毁子弹
        Destroy(gameObject);
    }
}
