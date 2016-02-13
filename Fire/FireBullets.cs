using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireBullets : MonoBehaviour {

	public GameObject DataCenter;
	public GameObject bullets;
	public GameObject bulletsOnGame;
	public GameObject Aim;
	private float nextfire = 0.0f;
	private float firerate = 0.1f; // 발사 속도
	private bool reload = false;

	/*GUI*/
	private GameObject Resolutions;
	private GameObject Console_Reload;
	private GameObject Console_Reload_OnGame;

	// Use this for initialization
	void Start () {
		DataCenter = GameObject.Find("DataCenter");
		Resolutions = GameObject.Find("Resolution");
		bullets = Resources.Load("Prefeb/InGame/bullets") as GameObject;
		Console_Reload = Resources.Load("Prefeb/OutGame/Reloading") as GameObject;
		Aim = GameObject.Find("Player/Aim");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0) && Time.time>nextfire && DataCenter.GetComponent<DataCenter>().GetNowSlot() > 0)
		{
			DataCenter.GetComponent<DataCenter>().LoseSlot();
			nextfire = Time.time + firerate;
			bulletsOnGame = (GameObject) Instantiate(bullets, Aim.transform.position, transform.rotation);
			bulletsOnGame.name = "bullets";
		}
		if((Input.GetKeyDown(KeyCode.R) || DataCenter.GetComponent<DataCenter>().GetNowSlot() == 0) 
			&& reload == false 
			&& (DataCenter.GetComponent<DataCenter>().GetNowSlot() != DataCenter.GetComponent<DataCenter>().Get_Now_maxSlot()))
		{
			//알람
			Console_Reload_OnGame = (GameObject) Instantiate(Console_Reload, new Vector3(Screen.width - Screen.width / 10, Screen.height * 9 / 10 ,0f), Quaternion.identity);
			Console_Reload_OnGame.GetComponent<RectTransform>().localScale = new Vector3(0.33f,0.33f,0.33f);
			Console_Reload_OnGame.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
			Console_Reload_OnGame.transform.SetParent(Resolutions.transform);
			
			//장전
			reload = true;
			nextfire = Time.time + 2;
		}

		//재장전 실행
		if(reload == true && Time.time > nextfire)
		{
			reload = false;
			DataCenter.GetComponent<DataCenter>().Reload();
			Destroy(Console_Reload_OnGame);
		}
	}
}
