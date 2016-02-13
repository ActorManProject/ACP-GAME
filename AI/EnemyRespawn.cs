using UnityEngine;
using System.Collections;

public class EnemyRespawn : MonoBehaviour {
	public GameObject[] enemies;
	public int amount;
	public int limit;
	private Vector3 spawnPoint;
	private GameObject Enemy; 
	private GameObject HealthBox;
	private GameObject SlotBox;
	private GameObject Player;

	void Start()
	{
		Enemy = Resources.Load("Prefeb/DemoGame/Enemy") as GameObject;
		HealthBox = Resources.Load("Prefeb/InGame/Medikit") as GameObject;
		SlotBox = Resources.Load("Prefeb/InGame/RifleKit") as GameObject;

		//디버그
		Player = GameObject.Find("Player");
	}

	void Update()
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		amount = enemies.Length;

		if(amount != limit)
		{
			InvokeRepeating("spawnEnemy", 5, 10f);
		}

		InvokeRepeating("spawnItem", 5, 10f);
	}

	void spawnEnemy()
	{
		spawnPoint.x = Random.Range (-8, 8);
		spawnPoint.y = 1;
		spawnPoint.z = Random.Range (-8, 8);
		
		if((spawnPoint.x < Player.transform.position.x + 1.5 && spawnPoint.x > Player.transform.position.x - 1.5) 
			&& (spawnPoint.y < Player.transform.position.y + 1.5 && spawnPoint.y > Player.transform.position.y- 1.5))
		{
			CancelInvoke();
		}	
		else
		{
			Instantiate(Enemy, spawnPoint, Quaternion.identity);
			CancelInvoke();
		}
	}

	void spawnItem()
	{
		var Item = (int) Random.Range(0, 10);
		
		switch (Item)
		{
			case 0 :
				//Debug.Log("HealthBox");
				spawnPoint.x = Random.Range (-8, 8);
				spawnPoint.y = 1;
				spawnPoint.z = Random.Range (-8, 8);
				Instantiate(HealthBox, spawnPoint, Quaternion.identity);
				CancelInvoke();
				break;
			case 1 :
				//Debug.Log("SlotBox");
				spawnPoint.x = Random.Range (-8, 8);
				spawnPoint.y = 1;
				spawnPoint.z = Random.Range (-8, 8);
				Instantiate(SlotBox, spawnPoint, Quaternion.identity);
				CancelInvoke();
				break;
			default :
				break;
		}
		
	}
}
