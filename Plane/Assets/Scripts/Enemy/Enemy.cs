using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType  //飞机的枚举类型
{
    smallEnemy,  //小型飞机
    middleEnemy, //中型飞机
    bossEnemy,    //大型飞机
}

public class Enemy : MonoBehaviour {
    public float life;
    public float speed;
    public int score;
    public EnemyType enemyType = EnemyType.smallEnemy;
    
    public bool isDead = false;
    public AudioClip destoryMusic;

    private float bossMoveMaxHeight;
    private int bossMoveDirection = 1;
    private float screenXMin, screenXMax;  //定义屏幕X轴最小，最大值

    Animator anim;  //存放动画组件

    public EnemyType planeType = EnemyType.smallEnemy;  //默认是小飞机

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>(); //获取动画组件

        SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;//获取当前飞机宽度
        bossMoveMaxHeight = Screen.height / 200.0f - spriteHeight / 2.0f;

        float spriteWeight = spriteRenderer.sprite.bounds.size.x;
        screenXMin = -Screen.width / 200.0f + spriteWeight / 2.0f;
        screenXMax = Screen.width / 200.0f - spriteWeight / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && bombManager._instance.count > 0)
        {
            life = -1;
            Behit();
            //如果按下了空格键，并且炸弹数目大于0，则把敌人的生命设为-1，全部执行爆炸动画    
        }
    }

    void Move()
    {
        if (enemyType != EnemyType.bossEnemy)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            if (transform.position.y > bossMoveMaxHeight)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * speed * bossMoveDirection * Time.deltaTime);

                Vector3 pos = transform.position;

                if (pos.x < screenXMin || pos.x > screenXMax)
                {
                    float x = pos.x;

                    x = x < screenXMin ? screenXMin : x;    //如果往左移动超出了屏幕最左边(最小值),则把最左边的坐标赋值给x
                    x = x > screenXMax ? screenXMax : x;    //同上

                    transform.position = new Vector3(x, pos.y, 0);  //重新改变飞机的位置

                    bossMoveDirection *= -1;
                }
            }
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
