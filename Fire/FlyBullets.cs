using UnityEngine;
using System.Collections;

public class FlyBullets : MonoBehaviour {
	
	public float bulletSpeed;

	public float bulletLifeTime; // 2sec

	FlyBullets()
	{
		
		bulletSpeed = 30f;

		bulletLifeTime = 0.5f; // defualt bullet life time
	}
	
	// Update is called once per frame
	void Update () {
		bulletLifeTime = bulletLifeTime - Time.deltaTime; // afther 2sec, auto destroyed
		if(bulletLifeTime <= 0)
		{
			Destroy(gameObject);
		}
		
		transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
	
}
