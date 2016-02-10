using UnityEngine;
using System.Collections;

public class FireBullets : MonoBehaviour {

	private GameObject bullets;
	private GameObject bulletsOnGame;
	private GameObject Aim;
	private float nextfire = 0.0f;
	private float firerate = 0.1f; // 발사 속도
	
	// Use this for initialization
	void Start () {
		bullets = Resources.Load("bullets") as GameObject;
		Aim = GameObject.Find("Player/Aim");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && Time.time>nextfire)
		{
			nextfire = Time.time + firerate;
			bulletsOnGame = (GameObject) Instantiate(bullets, Aim.transform.position, transform.rotation);
			bulletsOnGame.name = "bullets";
		}
	}
}
