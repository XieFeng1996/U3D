using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroHealth : MonoBehaviour
{
    private int life;
    public bool isDead = false;
    public AudioClip destoryMusic;

    // Use this for initialization
    void Start()
    {
        life = gamedoing._instance.playerAirLife;
    }

    void Behit(int damage)   //被击中时从子弹发过来的消息调用的方法
    {
        if (isDead)
            return;

        life -= damage;  //生命值减少
        gamedoing._instance.playerAirLifeInGame = life;

        if (life <= 0)
        {
            isDead = true;
            AudioSource.PlayClipAtPoint(destoryMusic, transform.localPosition);
            Dead();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)  //主角碰撞检测代码
    {
        if (other.tag == "Enemy")
        {
            if (!other.GetComponent<EnemyHealth>().isDead)
            {
                isDead = true;
                AudioSource.PlayClipAtPoint(destoryMusic, transform.localPosition);
                Dead();
            }
        }
    }

    void Dead()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("03");
    }
}
