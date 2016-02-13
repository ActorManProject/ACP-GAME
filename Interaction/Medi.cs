using UnityEngine;
using System.Collections;

public class Medi : MonoBehaviour {

	public int add_Health;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Characters>().health += add_Health;
			Destroy(gameObject);
		}
	}

}
