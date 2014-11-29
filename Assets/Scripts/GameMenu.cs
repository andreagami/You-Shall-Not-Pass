using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
  
    private int width = Screen.width;
    private int height = Screen.height;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(width / 2 - 100, height / 2 -60, 200, 50), "Jogar"))
        {
            Application.LoadLevel("Game");
        }
        if (GUI.Button(new Rect(width / 2 - 100, height / 2, 200, 50), "Recordes"))
        {
            // Application.LoadLevel("")
        }
        if (GUI.Button(new Rect(width / 2 - 100, height / 2 + 60, 200, 50), "Deslogar"))
        {
            Application.LoadLevel("Login");
        }
    }
}
