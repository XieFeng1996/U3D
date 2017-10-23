using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroHealth : MonoBehaviour {
    public float life;
    public bool isDead = false;
    public AudioClip destoryMusic;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
        }
    }

    public void OnTriggerEnter2D(Collider2D other)  //主角碰撞检测代码
    {
        if (other.tag == "Enemy")
        {
            if (!other.GetComponent<Enemy>().isDead)
            {
                anim.SetBool("Dead", true);
                AudioSource.PlayClipAtPoint(destoryMusic, transform.localPosition);
                //Invoke("Dead", 0.4f);
            }
        }
    }

    void Dead()
    {
        Destroy(this.gameObject);
        //GameOver._instance.showScore(GameMananger._instance.score);
        SceneManager.LoadScene("03");
    }
}
