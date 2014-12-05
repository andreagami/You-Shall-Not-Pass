using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {

    public GameObject planeObject; 
    private GUIText scoreText;
    private GUIText highScoreText;
    public int score;
    public int highScore;

	// Use this for initialization
	void Start () {
        scoreText = (GUIText)GameObject.Find("Plane/Score").GetComponent("GUIText");
        highScoreText = (GUIText)GameObject.Find("Plane/HighScore").GetComponent("GUIText");

        GetHighScore();
	}

    private void GetHighScore()
    {
        var queryScore = ParseObject.GetQuery("HighScore")
                .WhereEqualTo("playerName", ParseUser.CurrentUser.Username)
                .OrderByDescending("createdAt")
                .Limit(10);

        queryScore.FirstAsync().ContinueWith(t =>
        {
            ParseObject scoreObj = t.Result;
            score = scoreObj.Get<int>("score");
        });

        var queryHighScore = ParseObject.GetQuery("HighScore")
                .WhereEqualTo("playerName", ParseUser.CurrentUser.Username)
                .OrderByDescending("score")
                .Limit(10);

        queryHighScore.FirstAsync().ContinueWith(t =>
        {
            ParseObject highScoreObj = t.Result;
            highScore = highScoreObj.Get<int>("score");
        });
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 120, 10, 100, 50), "Quit Game"))
        {
            Application.LoadLevel("GameMenu");
        }
    }
}
