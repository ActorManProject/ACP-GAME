using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataCenter : MonoBehaviour {

	private List<Things> C_List = new List<Things>(); // Character List
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
			Debug.Log("Add New Obj_" + C_List[C_List.Count - 1]);
			
			//Give Obj a id
			C_List[C_List.Count - 1].Set_Id(C_List.Count - 1);
			Debug.Log("Take id_" + C_List[C_List.Count - 1].Get_Id());

		}
		else if(Player_Length > C_List.Count)
		{
			//Reset Id
			Debug.Log("Delete Obj");
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
}