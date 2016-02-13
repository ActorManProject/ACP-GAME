using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour {

	private void OnGUI()
	{
        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 1.5f , Screen.width / 5 , Screen.height / 20), "ReStart"))
        {
        	SceneManager.LoadScene("TestServer");
        }
    }

}
