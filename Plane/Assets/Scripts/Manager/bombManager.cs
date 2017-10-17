using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bombManager : MonoBehaviour {

    public GameObject boomIcon;  //炸弹的图标
    public Text boomNumber;    //炸弹的数目(用来显示)
    public int count = 0;     //炸弹的数量(用来运算)
    public static  bombManager _instance;  //单例初始化
	// Use this for initialization
	void Start () {
        _instance = this;    //初始化一个本类型
        boomIcon.SetActive(false);  //刚开始不显示图标
        boomNumber.gameObject.SetActive(false);     //不显示炸弹的数目
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
            boomNumber.text = "X" + count; //显示出来
            if (count <= 0)  //如果小于等于0
            {
                boomIcon.SetActive(false);  //则不显示
                boomNumber.gameObject.SetActive(false);
            }
        }
        
    }
	// Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombManager._instance.count > 0)
        {
            this.useAbomb();
            //每帧检查是否按下了空格键，如果按下了并且炸弹数目大于0 则调用减少一个炸弹方法
        }
    }
   
}
