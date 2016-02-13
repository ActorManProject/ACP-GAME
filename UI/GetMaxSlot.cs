using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetMaxSlot : MonoBehaviour {

	private GameObject DataCenter;
	int slot;

	// Use this for initialization
	void Start () {
		DataCenter = GameObject.Find("DataCenter");
	}
	
	// Update is called once per frame
	void Update () {
		slot = DataCenter.GetComponent<DataCenter>().GetMaxSlot();
		GetComponent<Text>().text = slot.ToString();
	}
}
