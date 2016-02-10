using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour {
	public GameObject[] Enemies;
	private GameObject Enemy_Sign;
	public GameObject[] new_Enemy_Sign;
	private Vector3 enemyPosition;
	private float MinimapArea;
	private float MinimapConversion;
	private int EnemiesCount;
	static int Number;

	Minimap()
	{
		Number = 0;
		MinimapConversion = 15;
		MinimapArea = 3.4f;
	}

	void Start()
	{
		Enemies = GameObject.FindGameObjectsWithTag("Enemy"); // find all Enemies in the game.
		Enemy_Sign = Resources.Load("Prefeb/OutGame/Enemy_Sign") as GameObject;
		for(int i = 0; i < Enemies.Length; i++)
		{
			makeSign(new Vector3(0,0,0));
		}
		EnemiesCount = Enemies.Length;
	}
	
	void Update()
	{	
		updateUnit();
		updateSign();
	}

	public void makeSign(Vector3 enemyPosition)
	{
		Instantiate(Enemy_Sign, enemyPosition, Quaternion.identity);
		new_Enemy_Sign = GameObject.FindGameObjectsWithTag("Sign");
		foreach(var x in Enemies)
		{
			x.GetComponent<Enemy>().EnemyNumber = Number;
			x.name = "Enemy" + Number++;
		}
		foreach(var x in new_Enemy_Sign)
		{
			x.transform.SetParent(this.transform,false); // parent - child relationship
		}
	}

	void updateUnit()
	{
		Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		EnemiesCount = Enemies.Length;
		if(EnemiesCount != transform.childCount) // if new unit added or deleted
		{
			if(EnemiesCount > transform.childCount) // added or deleted
			{
				makeSign(new Vector3(0,0,0));
			}
			else // deleted
			{
				var tempSign = GameObject.FindGameObjectsWithTag("Sign");
				foreach(var x in tempSign)
				{
					Destroy(x);
				}
				GroupResize(0, ref new_Enemy_Sign); 
			}
		}
	}

	void updateSign()
	{
		int i = 0;
		foreach(var x in new_Enemy_Sign)
		{
			var relX = Enemies[i].GetComponent<GetDistance>().relGetX() * MinimapConversion;
			var relY = Enemies[i].GetComponent<GetDistance>().relGetZ() * MinimapConversion;
			var distance = Enemies[i].GetComponent<GetDistance>().getDistance();		
			var angle = Mathf.Atan2(relY, relX);
			if(distance > MinimapArea)
			{
				relY = MinimapArea * MinimapConversion * Mathf.Sin(angle);
				relX = MinimapArea * MinimapConversion * Mathf.Cos(angle);
			}
			x.GetComponent<RectTransform>().localPosition = new Vector3
			(relX,relY,0);
			i++;
		}
	}

	public void GroupResize (int Size, ref GameObject[] Group)
	{       
    	GameObject[] temp = new GameObject[Size];
    	for(int c = 1; c < Mathf.Min(Size, Group.Length); c++ ) 
    	{
        	temp [c] = Group [c];
        }
     	Group = temp;
 	}
}
