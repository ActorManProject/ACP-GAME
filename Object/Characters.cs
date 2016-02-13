using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Characters : Things {

	public float move_speed;
	public bool humanity;
	public GameObject deathSprite;
	private GameObject deathSpriteOnGame;

	protected Characters()
	{
		humanity = false;
		health = 100;
		shield = 0;
		move_speed = 1;
	}

	// Use this for initialization
	protected override void Start () {
		
		// To be connected with DataCenter
		base.Start();

		deathSprite = Resources.Load("Prefeb/DemoGame/enemy_dead") as GameObject;
	}
	
	// Update is called once per frame
	void Update()
	{
		Health();
		Shield();
		Death();
	}

	void Health()
	{
		if(health > 100)
		{
			health = 100;
		}
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
			if(humanity == true) // respawn
			{
				SceneManager.LoadScene("TestServer_End");
			}
			else
			{
				deathSpriteOnGame = (GameObject) Instantiate(deathSprite, transform.position,  transform.rotation );
				deathSpriteOnGame.transform.rotation = Quaternion.Euler(90, 0, 0);
				Destroy(gameObject);
			}
		}
	}

	public override void Set_Id(int _id) { id = _id; }

	public override int Get_Id() { return id; }
}
