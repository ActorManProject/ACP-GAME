using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetShield : MonoBehaviour {

	private GameObject Player;
	int shield;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		shield = (int) Player.GetComponent<Characters>().shield;
		GetComponent<Text>().text = shield.ToString();
	}

}
