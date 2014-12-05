using UnityEngine;
using System.Collections;

public class BuyingMenu : MonoBehaviour {

    private Rect menu;
    private Rect buttons;
    private Transform towerPosition;
    private Quaternion rotation;
    public Camera mainCamera;
    public GameObject towerOne;
    public GameObject towerAux;
    private RaycastHit collision;
    private Ray radius;
    public int text;
    public int money;
    public int score;
    private bool canCreate;

	// Use this for initialization
	void Start () {
        text = 0;
        money = 100;
        score = 0;
        rotation.x = 0;
        rotation.y = 0;
        rotation.z = 0;
        canCreate = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            if (canCreate)
            {
                canCreate = false;
                radius = mainCamera.ScreenPointToRay(Input.mousePosition);
                text = 1;
                if (Physics.Raycast(radius, out collision, Mathf.Infinity))
                {
                    if (collision.transform.tag == "Tower 1")
                    {
                        text = 2;
                        towerPosition = collision.transform;
                    }
                }
                menu.x = Input.mousePosition.x;
                menu.y = -(Input.mousePosition.y - Screen.height);
                menu.height = Screen.height / 5;
                menu.width = Screen.width / 5;
                if ((menu.x + menu.width) > Screen.width)
                {
                    menu.x -= (menu.x + menu.width - Screen.width);
                }
                if ((menu.y + menu.height) > Screen.height)
                {
                    menu.y -= (menu.y + menu.height - Screen.height);
                }
            }
            else
            {
                canCreate = true;
                text = 0;
            }
	    }
	}

    void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(10, 10, 100, 50), "Gold: " + money);
        GUI.Label(new Rect(10, 40, 100, 50), "Score: " + score);
        if (GUI.Button(new Rect(Screen.width - 120, 10, 100, 50), "Quit Game"))
        {
            Application.LoadLevel("GameMenu");
        }
        if (text == 1)
        {
            GUI.Window(0, menu, Torres, "Towers");
        }
    }

    private void Torres(int id)
    {
        buttons.x = 10;
        buttons.y = 20;
        buttons.width = menu.width - 20;
        buttons.height = menu.height / 2 - 12;
        if (money >= 55)
        {
            GUI.color = Color.yellow;
        }
        else
        {
            GUI.color = Color.red;
        }
        if (GUI.Button(buttons, "Tower 1 - 50 gold"))
        {
            if (money >= 55)
            {
                towerAux = (GameObject)Instantiate(towerOne, transform.position, rotation);
                canCreate = true;
                text = 0;
            }
        }
        buttons.y += menu.height / 2 - 12;
        if (money >= 45)
        {
            GUI.color = Color.yellow;
        }
        else
        {
            GUI.color = Color.red;
        }
    }
    
}
