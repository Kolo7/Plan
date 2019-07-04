using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //按键控制飞机运动
    public float speed = 10.0f;
	public int hp = 100;
	public GameObject playerExp;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //检测左键是否被按下 Input
        //x:Vector3.right
        //y:Vector3.up
        //z:Vector3.forward
        //Time.deltaTime:从上一帧到这一帧的时间
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= Vector3.forward * Time.deltaTime * speed;
        }
    }


    //鼠标拖拽
    private void OnMouseDrag()
    {
        //飞机的坐标与鼠标的坐标相同
        //Input.mousePosition 鼠标坐标
        //transform.position 飞机坐标
        //将屏幕坐标转为世界坐标（屏幕→世界）
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //pos.y改为0
        pos.y = 0;
        //将pos赋值给飞机的赋值
        transform.position = pos;
    }

	public void Hurt(int damage){
		CameraShake.shake = 0.3f;
		switch (Application.platform) {
		case RuntimePlatform.Android:
			Handheld.Vibrate ();	
			break;
		}

		hp -= damage;
		if(hp<=0){
			GameObject exp = Instantiate (playerExp,transform.position ,Quaternion.identity);
			Destroy(gameObject);
			Destroy (exp, 1f);
		}
	}


}