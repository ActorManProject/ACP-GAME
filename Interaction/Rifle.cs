using UnityEngine;
using System.Collections;

public class Rifle : MonoBehaviour {
	GameObject DataCenter;

	void Start()
	{
		DataCenter = GameObject.Find("DataCenter");
	}

	public int add_Slot;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			DataCenter.GetComponent<DataCenter>().SetMaxSlot(add_Slot);
			Destroy(gameObject);
		}
	}
}
