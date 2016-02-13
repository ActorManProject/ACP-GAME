using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

	private void OnGUI()
	{
        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 1.8f , Screen.width / 5 , Screen.height / 20), "Start"))
        {
        	SceneManager.LoadScene("TestServer");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 1.8f + Screen.height / 10, Screen.width / 5, Screen.height / 20), "Exit"))
        {
        	Application.Quit();
        }
        
    }

}
