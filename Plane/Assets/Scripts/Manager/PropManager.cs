using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PropManager : MonoBehaviour
{
    private GameObject hero;

    public GameObject doubleBulletIcon;  //双枪的图标
    public Text doubleBulletText;    //双枪的剩余时间(用来显示)

    public GameObject threeBulletIcon;  //三枪的图标
    public Text threeBulletText;    //三枪的剩余时间(用来显示)

    public GameObject sideWeaponIcon;  //副武器的图标
    public Text sideWeaponText;    //副武器的剩余时间(用来显示)

    public GameObject boomIcon;  //炸弹的图标
    public Text boomNumber;    //炸弹的数目(用来显示)
    public int count = 0;     //炸弹的数量(用来运算)
    public AudioClip useBombMusic;

    public static PropManager _instance;  //单例初始化

    void Awake()
    {
        _instance = this;    //初始化一个本类型
    }

    // Use this for initialization
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");

        doubleBulletIcon.SetActive(false);  //刚开始不显示双枪图标
        doubleBulletText.gameObject.SetActive(false);     //不显示双枪的剩余时间

        threeBulletIcon.SetActive(false);  //刚开始不显示三枪图标
        threeBulletText.gameObject.SetActive(false);     //不显示三枪的剩余时间

        sideWeaponIcon.SetActive(false);  //刚开始不显示副武器图标
        sideWeaponText.gameObject.SetActive(false);     //不显示副武器的剩余时间

        boomIcon.SetActive(false);  //刚开始不显示炸弹图标
        boomNumber.gameObject.SetActive(false);     //不显示炸弹的数目
    }

    void Update()
    {
        //双枪图标更新
        float doubleGunTime = hero.GetComponent<HeroMainWeapon>().doubleGunTime;
        if (doubleGunTime > 0)
        {
            doubleBulletIcon.SetActive(true);
            doubleBulletText.gameObject.SetActive(true);
            doubleBulletText.text = ((int)doubleGunTime).ToString();
        }
        else
        {
            doubleBulletIcon.SetActive(false);
            doubleBulletText.gameObject.SetActive(false);
        }

        //三枪图标更新
        float threeGunTime = hero.GetComponent<HeroMainWeapon>().threeGunTime;
        if (threeGunTime > 0)
        {
            threeBulletIcon.SetActive(true);
            threeBulletText.gameObject.SetActive(true);
            threeBulletText.text = ((int)threeGunTime).ToString();
        }
        else
        {
            threeBulletIcon.SetActive(false);
            threeBulletText.gameObject.SetActive(false);
        }

        //副武器图标更新
        float sideGunTime = hero.GetComponent<HeroSideWeapon>().sideGunTime;
        if (sideGunTime > 0)
        {
            sideWeaponIcon.SetActive(true);
            sideWeaponText.gameObject.SetActive(true);
            sideWeaponText.text = ((int)sideGunTime).ToString();
        }
        else
        {
            sideWeaponIcon.SetActive(false);
            sideWeaponText.gameObject.SetActive(false);
        }
    }

    public void addAbomb()   //用来增加一个炸弹
    {
        count++;  //数量加一
        boomIcon.SetActive(true);  //设置显示
        boomNumber.gameObject.SetActive(true);
        boomNumber.text = "X " + count;  //显示炸弹的数目
    }

    public void useAbomb()   //使用了一个炸弹(炸弹减一)
    {
        if (count > 0)   //如果炸弹的数量大于0
        {
            count--; //则减少一个
            gamedoing._instance.usedPropsNumber++;
            boomNumber.text = "X" + count; //显示出来
            if (count <= 0)  //如果小于等于0
            {
                boomIcon.SetActive(false);  //则不显示
                boomNumber.gameObject.SetActive(false);
            }
            AudioSource.PlayClipAtPoint(useBombMusic, transform.localPosition);
        }

    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PropManager._instance.count > 0)
        {
            this.useAbomb();
            //每帧检查是否按下了空格键，如果按下了并且炸弹数目大于0 则调用减少一个炸弹方法
        }
    }

}
