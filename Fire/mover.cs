using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

	public Rigidbody rb;
	Vector3 spos, mpos, cpos, apos;
	float dy, dx, x = 1.58f, a;
	float deg, rad, deg1 = 0, r;
	public float acc = 0.5f, shellV = 5;

	void Start ()
	{
		
//마우스 위치 측정 및 변환
		spos = transform.position;
		mpos = Input.mousePosition;
		mpos.z = spos.z - Camera.main.transform.position.z;
		cpos = Camera.main.ScreenToWorldPoint (mpos);

//기존 탄환의 발사 각도 조정
		dy = cpos.y - spos.y;
		dx = cpos.x - spos.x;
		deg = Mathf.Atan2 (dy, dx)* Mathf.Rad2Deg;

//정확도
		deg = Random.Range((deg + deg1), (deg - deg1));

//탄환의 발사 속도 조절 - 항상 일정
		rad = deg / Mathf.Rad2Deg;
		apos.y = (Mathf.Sin (rad)); 
		apos.x = (Mathf.Cos (rad));

		apos.x *= shellV;
		apos.y *= shellV;

//실제로 부여
		rb = GetComponent<Rigidbody>();
		rb.velocity = apos;
		transform.rotation = Quaternion.Euler (0f, 0f, deg);

	}

}