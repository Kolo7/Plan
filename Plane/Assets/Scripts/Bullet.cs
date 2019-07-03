using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//向前移动
//当超出屏幕的时候销毁子弹
public class Bullet : MonoBehaviour {
    public float speed = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //向前移动
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //当坐标的Z值>=6时，销毁子弹
        if(transform.position.z >= 10f)
        {
            Destroy(gameObject);//销毁当前游戏物体
        }
	}
}
