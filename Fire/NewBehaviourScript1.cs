using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour
{


	public Vector3 spos, mpos, cpos;
	private float dy, dx, deg, rootv, nextfire = 0.0f;
	private int i;
	public float charV = 0.1f, firerate = 0.5f, reload = 3.0f;
	public GameObject go;
	public int state, on, ammo = 30, nowammo;

	void Start()
	{
		rootv = charV / Mathf.Sqrt(2);
		on = 0;
	}

	// Update is called once per frame
	void Update()
	{
		mpos = Input.mousePosition;
		mpos.z = spos.z - Camera.main.transform.position.z;
		cpos = Camera.main.ScreenToWorldPoint (mpos);

		dy = cpos.y - spos.y;
		dx = cpos.x - spos.x;
		deg = Mathf.Atan2(dy, dx)* Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, deg);
	


//방향키에 따라 속도 설정
		if( ((Input.GetKey(KeyCode.W))&&(!Input.GetKey(KeyCode.S))&&(!Input.GetKey(KeyCode.A))&&(!Input.GetKey(KeyCode.D))) || ((Input.GetKey(KeyCode.W))&&(!Input.GetKey(KeyCode.S))&&(Input.GetKey(KeyCode.A))&&(Input.GetKey(KeyCode.D))) )
		{
			spos.y += charV;
		}
		else if( ((!Input.GetKey(KeyCode.W))&&(Input.GetKey(KeyCode.S))&&(!Input.GetKey(KeyCode.A))&&(!Input.GetKey(KeyCode.D))) || ((!Input.GetKey(KeyCode.W))&&(Input.GetKey(KeyCode.S))&&(Input.GetKey(KeyCode.A))&&(Input.GetKey(KeyCode.D))) )
		{
			spos.y += -charV;
		}
		else if( ((!Input.GetKey(KeyCode.W))&&(!Input.GetKey(KeyCode.S))&&(Input.GetKey(KeyCode.A))&&(!Input.GetKey(KeyCode.D))) || ((Input.GetKey(KeyCode.W))&&(Input.GetKey(KeyCode.S))&&(Input.GetKey(KeyCode.A))&&(!Input.GetKey(KeyCode.D))) )
		{
			spos.x += -charV;
		}
		else if( ((!Input.GetKey(KeyCode.W))&&(!Input.GetKey(KeyCode.S))&&(!Input.GetKey(KeyCode.A))&&(Input.GetKey(KeyCode.D))) || ((Input.GetKey(KeyCode.W))&&(Input.GetKey(KeyCode.S))&&(!Input.GetKey(KeyCode.A))&&(Input.GetKey(KeyCode.D))) )
		{
			spos.x += charV;
		}
		else if( (Input.GetKey(KeyCode.W))&&(!Input.GetKey(KeyCode.S))&&(Input.GetKey(KeyCode.A))&&(!Input.GetKey(KeyCode.D)) )
		{
			spos.y += rootv;
			spos.x += -rootv;
		}
		else if( (Input.GetKey(KeyCode.W))&&(!Input.GetKey(KeyCode.S))&&(!Input.GetKey(KeyCode.A))&&(Input.GetKey(KeyCode.D)) )
		{
			spos.y += rootv;
			spos.x += rootv;
		}
		else if( (!Input.GetKey(KeyCode.W))&&(Input.GetKey(KeyCode.S))&&(!Input.GetKey(KeyCode.A))&&(Input.GetKey(KeyCode.D)) )
		{
			spos.y += -rootv;
			spos.x += rootv;
		}
		else if( (!Input.GetKey(KeyCode.W))&&(Input.GetKey(KeyCode.S))&&(Input.GetKey(KeyCode.A))&&(!Input.GetKey(KeyCode.D)) )
		{
			spos.y += -rootv;
			spos.x += -rootv;
		}

//단발, 점사, 연사 선택
		this.transform.position = spos;
		if(Input.GetKeyDown(KeyCode.V))
		{
			state++;
		}

//발사모드 + 발사, 재장전
		if (nowammo == 0) {
			nextfire = Time.time + reload;
			nowammo = ammo;
		}
		if ((state % 3) == 0) //단발
		{
			if(Input.GetMouseButtonDown(0)&&Time.time>nextfire)
			{
				nextfire = Time.time + firerate;
				Instantiate (go, spos, Quaternion.Euler (0f, 0f, 0f));
				nowammo--;
			}
		}
		else if ((state % 3) == 1) //3점사
		{
			if ( (( Input.GetMouseButtonDown(0) && (on == 0)) || ( on > 0 )) && (Time.time > nextfire)) {
				if (on == 0) {
					on = 3;
				}
				if (nowammo < 3) {
					on = nowammo;
				}
				nextfire = Time.time + firerate;
				Instantiate (go, spos, Quaternion.Euler (0f, 0f, 0f));
				on--;
				nowammo--;
			}
		}
		else if ((state % 3) == 2) //연사
		{
			if(Input.GetMouseButton(0)&&Time.time>nextfire)
			{
				nextfire = Time.time + firerate;
				Instantiate (go, spos, Quaternion.Euler (0f, 0f, 0f));
				nowammo--;
			}
		}

	
	}
}