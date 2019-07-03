using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 脚本名必须与类名相同
 */
public class Bg : MonoBehaviour {
    public float speed = 0.2f;
    public MeshRenderer meshRenderer;//面板上的MeshRender组件
	// 使Start初始化：只执行一次
	void Start () {
		
	}
	
	// Update每一帧调用
	void Update () {
        //offset的y值随着时间增加：1.纹理对应的名字 2.二维向量
        //Time.time：从游戏开始到现在的时间
        meshRenderer.material.SetTextureOffset("_MainTex",
            new Vector2(0,Time.time * speed));
	}
}
