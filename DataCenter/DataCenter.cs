using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataCenter : MonoBehaviour {

	private List<Things> C_List = new List<Things>(); // Character List
	private Player_Info player_info = new Player_Info();
	private int Player_Length;

	// Use this for initialization
	void Start () {
		Player_Length = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		is_Obj_Added();
		Renew_Player_Length();
	
	}

	// Add a GameObject if it respwan
	public void Connect(Things Who) {

		C_List.Add(Who);

	}

	void Renew_Player_Length() {
	
		Player_Length = C_List.Count;
	
	}

	void is_Obj_Added()
	{
		
		if(Player_Length < C_List.Count)
		{
			
			//Debug on Console
			//Debug.Log("Add New Obj_" + C_List[C_List.Count - 1]);
			
			//Give Obj a id
			C_List[C_List.Count - 1].Set_Id(C_List.Count - 1);
			//Debug.Log("Take id_" + C_List[C_List.Count - 1].Get_Id());

		}
		else if(Player_Length > C_List.Count)
		{
			//Reset Id
			//Debug.Log("Delete Obj");
			var i = 0;
			foreach(var x in C_List)
			{
				x.Set_Id(i++);
			}
		}
	}

	public void Delete_List(int id)
	{
		C_List.RemoveAt(id);
	}

	public int Get_Length()
	{
		return Player_Length;
	}

	public Things Get_Value(int index)
	{
		return C_List[index];
	} 

	public void Reload()
	{
		player_info.Reload();
	}

	public int GetNowSlot()
	{
		return player_info.GetNowSlot();
	}

	public int GetMaxSlot()
	{
		return player_info.GetMaxSlot();
	}

	public void LoseSlot()
	{
		player_info.LoseSlot();
	}
	public int Get_Now_maxSlot()
	{
		return player_info.Get_Now_maxSlot();
	}

	public void SetMaxSlot(int add)
	{
		player_info.setMaxSlot(add);
	}
}

public class Player_Info
{
	/* 
	NOT YET USED
	private float health;
	private	flaot shield;
	private string weapone[];
	*/
	//나중에 이부분 총 정보에 들어갈 예정
	private int nowSlot = 30;
	private const int now_maxSlot = 30;
	private int maxSlot = 90;
	private const int max_maxSlot = 990;
	//

	public void setNowSlot(int add)
	{
		nowSlot += add;
	}

	public void setMaxSlot(int add)
	{
		maxSlot += add;
	}

	public void Reload()
	{
		if(maxSlot != 0)
		{
			if(nowSlot != now_maxSlot)
			{
				var need_bullet = now_maxSlot - nowSlot;
				if(maxSlot < need_bullet)
				{
					need_bullet = maxSlot;
				}
				maxSlot -= need_bullet;
				nowSlot += need_bullet;
			}
		}
	}

	public int GetNowSlot()
	{
		return nowSlot;
	}

	public int GetMaxSlot()
	{
		return maxSlot;
	}

	public void LoseSlot()
	{
		nowSlot -= 1;
	}

	public int Get_Now_maxSlot()
	{
		return now_maxSlot;
	}

}