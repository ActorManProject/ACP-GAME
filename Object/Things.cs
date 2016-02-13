using UnityEngine;
using System.Collections;

abstract public class Things : MonoBehaviour {

	protected int id;
	public float health;
	public float shield;

	protected virtual void Start()
	{
		
		// To Connect DataCenter with This Obejct
		var DataCenter = GameObject.Find("DataCenter");
		DataCenter.GetComponent<DataCenter>().Connect(this);
	
	}

	void OnDestroy() 
	{	
		// when destroy, remove missing pointer
		if(health <= 0 && gameObject.tag != "Player") // 정삭적인 죽음에 대해서만
		{
			var DataCenter = GameObject.Find("DataCenter");
			DataCenter.GetComponent<DataCenter>().Delete_List(id);
		}
	}

	public virtual void Set_Id(int _id) { id = _id; }

	public virtual int Get_Id() { return id; }

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Bullets" ) // bumped bullets
		{
			health -= collision.gameObject.GetComponent<BulletsStats>().damage; // get damage
		}
	}
}