using UnityEngine;
using System.Collections;

public class Characters : Things {

	public float move_speed;

	Characters()
	{
		health = 100;
		shield = 0;
		move_speed = 1;
	}

	// Use this for initialization
	protected override void Start () {
		
		// To be connected with DataCenter
		base.Start();

	}
	
	// Update is called once per frame
	void Update()
	{
		Shield();
		Death();
	}

	void Shield()
	{
		if(shield <= 0)
		{
			shield = 0;
		}
	}

	void Death()
	{
		if(health <= 0 && shield <= 0)
		{
			Destroy(gameObject);
		}
	}
}
