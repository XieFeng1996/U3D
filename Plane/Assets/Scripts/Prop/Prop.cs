using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropType  //道具的枚举类型
{
    doubleBullet,  //双枪补给
    threeBullet,  //三枪补给
    Side_Weapon,  //副武器补给
    Shield,  //防护罩补给
    boom,  //炸弹补给
}

public class Prop : MonoBehaviour {
    public float speed;

    public PropType propType = PropType.doubleBullet;  //默认是双枪补给

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        //补给超出屏幕边界后销毁补给
        Destroy(gameObject);
    }
}
