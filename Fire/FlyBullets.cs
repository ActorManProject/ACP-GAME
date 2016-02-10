using UnityEngine;
using System.Collections;

public class FlyBullets : MonoBehaviour {
	
	public float bulletSpeed;

	FlyBullets()
	{
		bulletSpeed = 30f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
	
}
