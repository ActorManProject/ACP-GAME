using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {
	private GameObject bullets;
	private GameObject bulletsOnGame;
	public GameObject Aim;
	public float fireRate = 0.5f;
	private float nextFire = 0;

	void Start () 
	{
		bullets = Resources.Load("Prefeb/InGame/bullets(Enemy)") as GameObject;
	}

	void Update()
	{
		Aim = GameObject.Find("Enemy" + transform.parent.gameObject.GetComponent<Enemy>().EnemyNumber + "/Aim");
	}
	void OnTriggerStay(Collider Player)
	{
		if(Player.tag == "Player" && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			bulletsOnGame = (GameObject) Instantiate(bullets, Aim.transform.position, transform.rotation);
			bulletsOnGame.name = "bullets";
		}
	}
}
