using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetHealth : MonoBehaviour {

	private GameObject Player;
	int health;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		health = (int) Player.GetComponent<Characters>().health;
		GetComponent<Text>().text = health.ToString();
	}
}
