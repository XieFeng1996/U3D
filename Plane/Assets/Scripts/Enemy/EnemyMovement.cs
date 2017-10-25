using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2;

    private float bossMoveMaxHeight;
    private int bossMoveDirection = 1;
    private float screenXMin, screenXMax;  //定义屏幕X轴最小，最大值

    // Use this for initialization
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;//获取当前飞机高度
        bossMoveMaxHeight = Screen.height / 200.0f - spriteHeight / 2.0f;

        float spriteWeight = spriteRenderer.sprite.bounds.size.x;//获取当前飞机宽度
        screenXMin = -Screen.width / 200.0f + spriteWeight / 2.0f;
        screenXMax = Screen.width / 200.0f - spriteWeight / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (GetComponent<EnemyHealth>().enemyType != EnemyType.bossEnemy)
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

                    x = x < screenXMin ? screenXMin : x;
                    x = x > screenXMax ? screenXMax : x;

                    transform.position = new Vector3(x, pos.y, 0);

                    bossMoveDirection *= -1;
                }
            }
        }
    }

    void OnBecameInvisible()
    {
        //飞机超出屏幕边界后销毁飞机
        Destroy(gameObject);
    }
}
