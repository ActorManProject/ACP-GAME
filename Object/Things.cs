using UnityEngine;
using System.Collections;

abstract public class Things : MonoBehaviour {

	protected int id;
	public float health;
	public float shield;

	protected virtual void Start()
	{
		
		// To Connect DataCenter with This Obejct
		GameObject DataCenter = GameObject.Find("DataCenter");
		DataCenter.GetComponent<DataCenter>().Connect(this);
	
	}

	public void Set_Id(int _id) { id = _id; }

	public int Get_Id() { return id; }
}
