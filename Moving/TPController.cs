using UnityEngine;
using System.Collections;

public class TPController : MonoBehaviour {

	private int id;
	private Vector3 inputMovement;
	private Vector3 inputRotation;
	private Vector3 tempVector;
	private Vector3 tempVector2;
	private float move_speed;
	private GameObject objCamera;

	// Use this for initialization
	void Start () {
		objCamera = GameObject.FindWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{	
		UpdateData();
	}

	void Update ()
	{
		UpdateData();
		FindPlayerInput();
		ProcessMovement();
		HandleCamera();
	}

	void UpdateData()
	{
		move_speed = GetComponent<Characters>().move_speed; // Renew PlayerSpeed
	}

	void FindPlayerInput ()
	{
		inputMovement = new Vector3( Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical") ); // find vector to move
		// find vector to the mouse
		tempVector2 = new Vector3(Screen.width * 0.5f,0,Screen.height * 0.5f); // the position of the middle of the screen
		tempVector = Input.mousePosition; // find the position of the moue on screen
		tempVector.z = tempVector.y; // input mouse position gives us 2D coordinates, I am moving the Y coordinate to the Z coorindate in temp Vector and setting the Y coordinate to 0, so that the Vector will read the input along the X (left and right of screen) and Z (up and down screen) axis, and not the X and Y (in and out of screen) axis
		tempVector.y = 0;
		inputRotation = tempVector - tempVector2; // the direction we want face/aim/shoot is from the middle of the screen to where the mouse is pointing
	}

	void ProcessMovement()
	{
		tempVector = GetComponent<Rigidbody>().GetPointVelocity(transform.position) * Time.deltaTime * 1000;
		GetComponent<Rigidbody>().AddForce (-tempVector.x, -tempVector.y, -tempVector.z);
		GetComponent<Rigidbody>().AddForce (inputMovement.normalized * move_speed * 10000 * Time.deltaTime);
		transform.rotation = Quaternion.LookRotation(inputRotation);
		transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
		transform.position = new Vector3(transform.position.x,1f,transform.position.z);
	}

	void HandleCamera()
	{
		objCamera.transform.position = new Vector3(transform.position.x,10,transform.position.z);
		objCamera.transform.eulerAngles = new Vector3(90,0,0);
	}
}
