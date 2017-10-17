using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public static float speed = 2;
    private static float spriteHeight;

	// Use this for initialization
	void Start () {
        SpriteRenderer spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        spriteHeight = spriteRenderer.sprite.bounds.size.y;//获取背景高度
	}
	
	// Update is called once per frame
	void Update () {
        //向下移动
		transform.Translate(new Vector3(0,-1,0)*speed*Time.deltaTime);

        //当移动了一个背景距离时，重置背景位置
        if (this.transform.position.y < -spriteHeight)
        {
            Vector3 newPos = transform.position;
            newPos.y += 2.0f * spriteHeight;
            transform.position = newPos;
        }
	}
}
