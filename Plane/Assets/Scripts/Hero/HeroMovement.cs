using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private bool isMouseDown = false;
    private Vector3 lastMousePosition;

    private float screenXMin, screenXMax;  //定义屏幕X轴最小，最大值
    private float screenYMin, screenYMax;  //定义屏幕Y轴最小，最大值

	// Use this for initialization
	void Start () {
        SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;

        float spriteWeight = spriteRenderer.sprite.bounds.size.x;
        screenXMin = -Screen.width / 200.0f + spriteWeight / 2.0f;
        screenXMax = Screen.width / 200.0f - spriteWeight / 2.0f;

        float spriteHeight = spriteRenderer.sprite.bounds.size.y;
        screenYMin = -Screen.height / 200.0f + spriteHeight / 2.0f;
        screenYMax = Screen.height / 200.0f - spriteHeight / 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        if (isMouseDown && GameMananger._instance.gs == GameState.Running)  //把鼠标所在的位置(屏幕)转换成世界坐标，移动时所产生的偏移与飞机所在的位置相加，使飞机移动
        {         
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
            transform.position = transform.position + offset;

            checkPosition();    //检查飞机有没有飞出屏幕
        }

        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//实时把鼠标的位置从屏幕坐标转换成世界坐标并赋值给lastpositon
	}

    void checkPosition()    //检查飞机有没有飞出屏幕
    {
        Vector3 pos = transform.position;
        float x = pos.x;
        float y = pos.y;

        //效果虽然和下面一样，但移植效果没下面的好
        x = x < screenXMin ? screenXMin : x;    //如果往左移动超出了屏幕最左边(最小值),则把最左边的坐标赋值给x
        x = x > screenXMax ? screenXMax : x;    //同上
        y = y < screenYMin ? screenYMin : y;    //同上
        y = y > screenYMax ? screenYMax : y;    //同上
        transform.position = new Vector3(x, y, 0);  //重新改变飞机的位置
    }
}
