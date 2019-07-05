using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//产生子弹
public class BulletSpwan : MonoBehaviour
{
    public GameObject bulletPre;
	public int isPlayer;
    // Use this for initialization
    void Start()
    {
        //重复调用:1.方法名 2.第一次调用的等到时间 3.频率
        //每隔0.1秒调用一次
		if(isPlayer==0)
        	InvokeRepeating("CreateBullet",0,0.2f);
		else
			InvokeRepeating("CreateBullet",0,0.8f);

    }

    // Update is called once per frame
    void Update()
    {
		if(isPlayer==0 && Input.GetKeyDown(KeyCode.Q) ){
			Fire ();
		}
    }

	public void Fire(){
		if (!IsInvoking ("SanDan")) {
			CancelInvoke ("CreateBullet");
			InvokeRepeating ("SanDan", 0, 0.2f);
			Invoke ("SanDanToNoraml",5);
		}	
	}

	void SanDan()
	{
		int num = 6;
		int angle = 60;
		for (int i = 0; i < num; i++) {
			GameObject ob = Instantiate(bulletPre,
				transform.position,
				Quaternion.Euler(new Vector3(0, i*angle/num-25, 0)));
		}
	}

	void SanDanToNoraml(){
		CancelInvoke ("SanDan");
		InvokeRepeating ("CreateBullet",0,0.2f);
	}
    void CreateBullet()
    {
		GameObject bullet =  Instantiate(bulletPre,
            transform.position,
            Quaternion.Euler(new Vector3(0, 0, 0)));
		if (isPlayer == 1)
			bullet.GetComponent<Bullet> ().setProperty (isPlayer);
    }
}