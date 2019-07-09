using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //按键控制飞机运动
    public float speed = 50.0f;
	public int hp = 100;
	public GameObject playerExp;
	public GameObject hudun;
	private BulletSpwan bullSpwan;
	public int hudunStatus;
	public float minX = -4.31f;
	public float maxX = 4.38f;
	public float minZ = -6.46f;
	public float maxZ = 6.68f;
	public Slider hpSlider;
	private GameObject socerManager;
    void Start()
    {
		
		bullSpwan = transform.Find ("BulletSpwan").GetComponent<BulletSpwan> ();
    }

    // Update is called once per frame
    void Update()
    {
		//OnMouseDrag ();
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



    private void OnMouseDrag()
    {

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.y = 0;
		transform.position = pos;
		if (transform.position.x <= minX)
			transform.position = new Vector3 (minX, 0, transform.position.z);
		if (transform.position.x >= maxX)
			transform.position = new Vector3 (maxX, 0, transform.position.z);
		if (transform.position.z<=minZ)
			transform.position = new Vector3 (transform.position.x, 0, minZ);
		if (transform.position.z>=maxZ)
			transform.position = new Vector3 (transform.position.x, 0, maxZ);


    }

	public void Hurt(int damage){
		if (hudunStatus == 1)
			return;
		CameraShake.shake = 0.3f;
		switch (Application.platform) {
		case RuntimePlatform.Android:
			Handheld.Vibrate ();	
			break;
		}

		hp -= damage;

		if(hp<=0){
			hp = 0;
			GameObject exp = Instantiate (playerExp,transform.position ,Quaternion.identity);
			socerManager = GameObject.FindGameObjectWithTag ("UIManager");
			socerManager.GetComponent<UIManager> ().Success ();
			socerManager.GetComponent<UIManager> ().AddRank ();
			GameObject ob = GameObject.FindGameObjectWithTag ("DieUI");
			Destroy(gameObject);
			Destroy (exp, 1f);
		}
		hpSlider.value = (float)hp/100f;
	}

	public void AddHP(int _hp){
		hp += _hp;
		if (hp > 100)
			hp = 100;
		hpSlider.value = (float)hp/100f;
	}

	public void Sandan(){
		bullSpwan.Fire ();
	}

	public void OpenHudun(){
		if (hudunStatus == 0) {
			hudun.SetActive (true);
			Invoke ("Closehudun",5);
			hudunStatus = 1;
		}
	}

	public void Closehudun(){
		hudun.SetActive (false);
		hudunStatus = 0;
	}
		
}