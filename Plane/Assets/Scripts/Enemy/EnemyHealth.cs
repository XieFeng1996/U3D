using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EnemyType  //飞机的枚举类型
{
    smallEnemy,  //小型飞机
    middleEnemy, //中型飞机
    bossEnemy,    //大型飞机
}

public class EnemyHealth : MonoBehaviour
{
    private float life;
    private int score;
    public EnemyType enemyType = EnemyType.smallEnemy;
    
    public bool isDead = false;
    public AudioClip destoryMusic;

    Animator anim;  //存放动画组件

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); //获取动画组件

        if (enemyType == EnemyType.smallEnemy)
        {
            life = gamedoing._instance.mobsLife1;
            score = gamedoing._instance.mobsGold1;
        }
        else if (enemyType == EnemyType.middleEnemy)
        {
            life = gamedoing._instance.mobsLife2;
            score = gamedoing._instance.mobsGold2;
        }
        else
        {
            life = gamedoing._instance.mobsLife3;
            score = gamedoing._instance.mobsGold3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && PropManager._instance.boomCount > 0)
        {
            if (enemyType != EnemyType.bossEnemy)
            {
                life = -1;
            }
            else
            {
                life = gamedoing._instance.mobsLife3 / 5;
            }
            Behit(0);
        }
    }

    void Behit(int damage)   //被击中时从子弹发过来的消息调用的方法
    {
        if (isDead)
            return;

        life -= damage;  //生命值减少

        if (life <= 0)
        {
            isDead = true;
            anim.SetBool("Dead", true);   //开始播放爆炸动画
            AudioSource.PlayClipAtPoint(destoryMusic, transform.localPosition);
            GameMananger._instance.addScore(score);
            gamedoing._instance.playerKillNumber++;
        }
        else
        {
            anim.SetBool("Hited", true);   //开始播放被击中动画
        }
    }

    void Dead()
    {
        Destroy(this.gameObject);

        if (enemyType != EnemyType.bossEnemy)
        {
            GetComponent<EnemyPropsDrop>().PropDrop();
        }
        else
        {
            GameMananger._instance.isWin = true;
            gamedoing._instance.gradingRule();
            SceneManager.LoadScene("03");
        }
    }

    void Hited()
    {
        anim.SetBool("Hited", false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shield")
        {
            if (enemyType != EnemyType.bossEnemy)
            {
                life = -1;
                other.gameObject.transform.parent.SendMessage("Behit", 3);
            }
            else
            {
                life = gamedoing._instance.mobsLife3 / 10;
                other.gameObject.transform.parent.SendMessage("Behit", 3);
            }
            Behit(0);
        }
    }
}
