using UnityEngine;
using System.Collections;

public class Characters : Things {

	public float move_speed;

	Characters()
	{
		health = 100;
		shield = 20;
		move_speed = 1;
	}

	// Use this for initialization
	protected override void Start () {
		
		// To be connected with DataCenter
		base.Start();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
