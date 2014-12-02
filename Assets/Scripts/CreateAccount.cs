using UnityEngine;
using System.Collections;
using Parse;

public class CreateAccount : MonoBehaviour {

    private string userName = string.Empty;
    private string password = string.Empty;
    private string password2 = string.Empty;
    private string email = string.Empty;
    private int width = Screen.width;
    private int height = Screen.height;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        //Cria label para 'Login'
        GUI.Label(new Rect(width / 2 - 500, height / 2 - 150, 100, 60), "Login");
        //Cria campo onde deverá ser inserido login
        userName = GUI.TextField(new Rect(width / 2 - 400, height / 2 - 150, 800, 60), userName);
        //Cria label 'Senha'
        GUI.Label(new Rect(width / 2 - 500, height / 2 - 60, 100, 60), "Senha");
        //Cria campo onde deverá ser inserido senha
        password = GUI.PasswordField(new Rect(width / 2 - 400, height / 2 - 60, 800, 60), password, "*"[0], 25);
        //Cria label 'Email'
        GUI.Label(new Rect(width / 2 - 500, height / 2 + 30, 100, 60), "Email:");
        //Cria campo onde deverá ser inserido email
        email = GUI.TextField(new Rect(width / 2 - 400, height / 2 + 30, 800, 60), email);
        //Cria botão
        if (GUI.Button(new Rect(width / 2 - 200, height / 2 + 120, 400, 50), "Ok"))
        {
            CreateNewUser(userName, password, email);
        }

    }
    void CreateNewUser(string userName, string password, string email)
    {
        var user = new ParseUser(){
            Username = userName,
            Password = password,
            Email = email
        };

        user.SignUpAsync();
        Application.LoadLevel("GameMenu");
    }
}
