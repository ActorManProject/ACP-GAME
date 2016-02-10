using UnityEngine;
using System.Collections;

public class AI_Controller : MonoBehaviour {
	public float moveSpeed;
	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player");
	}

	void FixedUpdate () 
	{
		facePlayer();
	}
	
	void facePlayer()
	{
		float y = Mathf.Atan2((Player.transform.position.z - transform.position.z), (Player.transform.position.x 
			- transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3(0, -y, 0);
		GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
	}
}
