using UnityEngine;
using System.Collections;
using System;
using Parse;

public class Login : MonoBehaviour {
	private string userName      = string.Empty;
	private string password      = string.Empty;
	private bool isAuthenticated = false;
	private bool isMainMenu      = false;
    private bool loginSuccess    = false;
    private int width            = Screen.width;
    private int height           = Screen.height;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		
		if (ParseUser.CurrentUser != null)
        {
			// Once user has been authenticated do stuff
			Application.LoadLevel("MenuInicial");
		}
        else
        {
			// show the signup or login screen
			ShowLoginGUI();
		}
	}
	
	void ShowLoginGUI()
    {
		//Cria um label 'Login'
		GUI.Label (new Rect (width / 2 - 500, height / 2 - 150, 100, 60), "Login:");
        //Cria um campo para inserir o Login
        userName = GUI.TextField(new Rect(width / 2 - 400, height / 2 - 150, 800, 60), userName);
		//Cria um label 'Senha'
        GUI.Label(new Rect(width / 2 - 500, height / 2 - 60, 100, 60), "Senha");
        //Cria um campo para inserir a senha
        password = GUI.PasswordField(new Rect(width / 2 - 400, height / 2 - 60, 800, 60), password, "*"[0], 25);

        if (GUI.Button(new Rect(width / 2 - 400, height / 2 + 20, 380, 50), "Entrar"))
        {
            authenticateUser(userName, password);
		}

        if (GUI.Button(new Rect(width / 2 + 20, height / 2 + 20, 380, 50), "Criar conta"))
        {
            Application.LoadLevel("CreateAccount");
		}
		
	}
	
	void authenticateUser(string username, string password)
    {
		
		ParseUser.LogInAsync(username, password).ContinueWith(t =>
		                                                      {
			if (t.IsFaulted || t.IsCanceled){
				// The login failed. Check t.Exception to see why.
				isAuthenticated = false;
			} else {
				// Login was successful.
				isAuthenticated = true;
                Application.LoadLevel("GameMenu");
			}
		});
	}
}
