using UnityEngine;
using System.Collections;

public class MovingAnimations : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Animate();
	}

	void Animate()
	{
		if(Input.GetKey(KeyCode.W) 
			|| Input.GetKey(KeyCode.A)
			|| Input.GetKey(KeyCode.S)
			|| Input.GetKey(KeyCode.D)
			 )
		{
			GetComponent<Animator>().SetTrigger("Walking");
		}
		
		if(!Input.GetKey(KeyCode.W)
			&& !Input.GetKey(KeyCode.A)
			&& !Input.GetKey(KeyCode.S)
			&& !Input.GetKey(KeyCode.D)
			)
		{
			GetComponent<Animator>().SetTrigger("Idle");
		}

	}
}
