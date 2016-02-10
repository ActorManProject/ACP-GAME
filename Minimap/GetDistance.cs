using UnityEngine;
using System.Collections;

public class GetDistance : MonoBehaviour {

	private GameObject Player;
	public float distance;
	private float player_X;
	private float player_Z;
	private float object_X;
	private float object_Z;
	private float rel_x; // relatively
	private float rel_z; // relatively

	void Start()
	{
		Player = (GameObject) GameObject.FindWithTag ("Player");
	}
	
	void Update()
	{
		updatePosition(); // to update position of player and object
		updateDistance();
	}

	void updatePosition()
	{
		player_X = Player.GetComponent<Transform>().position.x;
		player_Z = Player.GetComponent<Transform>().position.z;
		object_X = GetComponent<Transform>().position.x;
		object_Z = GetComponent<Transform>().position.z;
		rel_x = object_X - player_X;
		rel_z = object_Z - player_Z;
	}

	void updateDistance()
	{ // to update distance from player
		distance = Mathf.Sqrt(Mathf.Pow(player_X - object_X, 2f) + Mathf.Pow(player_Z - object_Z, 2f));
	}

	public float getDistance()
	{
		return distance;
	}

	public float relGetX()
	{
		return rel_x;
	}

	public float relGetZ()
	{
		return rel_z;
	}

}
