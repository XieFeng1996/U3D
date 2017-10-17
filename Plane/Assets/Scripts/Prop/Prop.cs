using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropType  //道具的枚举类型
{
    doubleBullet,  //双子弹补给
    threeBullet,  //三子弹补给
    Side_Weapon,
    boom,  //炸弹
}

public class Prop : MonoBehaviour {
    public float speed;

    public PropType propType = PropType.doubleBullet;  //默认是子弹补给

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        //飞机超出屏幕边界后销毁子弹
        Destroy(gameObject);
    }
}
