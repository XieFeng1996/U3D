using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    [System.Serializable]
    public class Plane
    {
        public GameObject plane;   //预制体
        public int creatTime;   //游戏刚开始时等待多少秒开始产生飞机
        public float creatRate;   //飞机产生频率
    }

    public Plane smallPlane;
    public Plane middlePlane;
    public GameObject bossPlane;

    private Coroutine smallPlaneCoroutine;
    private Coroutine middlePlaneCoroutine;

    private int bringNum = 0;

	// Use this for initialization
    void Start()
    {
        smallPlaneCoroutine = StartCoroutine(creatPlane(smallPlane));

        middlePlaneCoroutine = StartCoroutine(creatPlane(middlePlane));
    }

    IEnumerator creatPlane(Plane m_Plane)
    {
        yield return new WaitForSeconds(m_Plane.creatTime);

        creatEnemyPlane(m_Plane.plane);

        while (true)
        {
            yield return new WaitForSeconds(m_Plane.creatRate);

            creatEnemyPlane(m_Plane.plane);
        }
    }

    void creatEnemyPlane(GameObject plane)
    {
        SpriteRenderer spriteRenderer = plane.GetComponent<Renderer>() as SpriteRenderer;
        float spriteWeight = spriteRenderer.sprite.bounds.size.x;//获取当前飞机宽度
        float xMin = -Screen.width / 200.0f + spriteWeight / 2.0f;
        float xMax = Screen.width /200.0f - spriteWeight / 2.0f;
        Instantiate(plane, new Vector3(Random.Range(xMin, xMax),transform.position.y,0),Quaternion.identity);  //生成飞机

        bringNum++;

        if (bringNum == gamedoing._instance.bossAppearPlace)
        {
            creatEnemyPlane(bossPlane);
        }

        if (bringNum == gamedoing._instance.monsterCap)
        {
            StopCoroutine(smallPlaneCoroutine);

            StopCoroutine(middlePlaneCoroutine);
        }
    }
}
