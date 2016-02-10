using UnityEngine;
using System.Collections;

public class EnemyRespawn : MonoBehaviour {
	public GameObject[] enemies;
	public int amount;
	public int limit;
	private Vector3 spawnPoint;
	private GameObject Enemy; 

	void Start()
	{
		Enemy = Resources.Load("Prefeb/DemoGame/Enemy") as GameObject;
	}

	void Update()
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		amount = enemies.Length;

		if(amount != limit)
		{
			InvokeRepeating("spawnEnemy", 5, 10f);
		}
	}

	void spawnEnemy()
	{
		spawnPoint.x = Random.Range (-8, 8);
		spawnPoint.y = 1;
		spawnPoint.z = Random.Range (-8, 8);
	
		Instantiate(Enemy, spawnPoint, Quaternion.identity);
		CancelInvoke();
	}
}
