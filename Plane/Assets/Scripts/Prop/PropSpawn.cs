using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawn : MonoBehaviour {
    [System.Serializable]
    public class Prop
    {
        public GameObject prop;   //预制体
        public int creatTime;   //游戏刚开始时等待多少秒开始产生道具
        public float creatRate;   //道具产生频率
    }

    public Prop[] prop;    //储存道具

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < prop.Length; i++)
        {
            StartCoroutine(creatProp(prop[i]));
        }
    }

    IEnumerator creatProp(Prop m_Prop)
    {
        yield return new WaitForSeconds(m_Prop.creatTime);

        creatProp(m_Prop.prop);

        while (true)
        {
            yield return new WaitForSeconds(m_Prop.creatRate);

            creatProp(m_Prop.prop);
        }
    }

    void creatProp(GameObject prop)
    {
        SpriteRenderer spriteRenderer = prop.GetComponent<Renderer>() as SpriteRenderer;
        float spriteWeight = spriteRenderer.sprite.bounds.size.x;//获取当前道具宽度
        float xMin = -Screen.width / 200.0f + spriteWeight / 2.0f;
        float xMax = Screen.width / 200.0f - spriteWeight / 2.0f;
        Instantiate(prop, new Vector3(Random.Range(xMin, xMax), transform.position.y, 0), Quaternion.identity);  //生成道具
    }
}
