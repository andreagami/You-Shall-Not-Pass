using UnityEngine;
using System.Collections;

public class BuyingMenu : MonoBehaviour {

    public Camera mainCamera;

    Rect menu, buttons;
    public GameObject towerOne, towerTwo, towerAux;

    public int text, money, score;
    
    Transform towerPosition;

    //DestroyTorre AuxDestroiTorre;

	// Use this for initialization
	void Start () {
        text = 0;
        money = 100;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(1)){
		    Ray radius = mainCamera.ScreenPointToRay(Input.mousePosition);
		    RaycastHit collision;
		    text=1; 
		    if (Physics.Raycast(radius, out collision, Mathf.Infinity)){
			    if (collision.transform.tag=="Tower 1"){
				    text=2;
				    towerPosition = collision.transform;
			    }
			    if (collision.transform.tag=="Tower 2"){
				    text=3;
				    towerPosition = collision.transform;
			    }
			
			    //Destroy(transform);
		    }
		    menu.x = Input.mousePosition.x;
		    menu.y = -(Input.mousePosition.y-Screen.height);
		    menu.height = Screen.height/5;
		    menu.width = Screen.width/5;
		    if ((menu.x+menu.width)>Screen.width){
			    menu.x -= (menu.x+menu.width-Screen.width);
		    }
		    if ((menu.y+menu.height)>Screen.height){
			    menu.y -= (menu.y+menu.height-Screen.height);
		    }
	    }
	}

    void OnGUI()
    {
        GUI.color = Color.yellow;
        GUI.Label(new Rect(10, 10, 100, 50), "Gold: " + money);
        GUI.Label(new Rect(10, 40, 100, 50), "Score: " + score);

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
        if (GUI.Button(buttons, "Tower 1 - 55 gold"))
        {
            if (money >= 55)
            {
                towerAux = (GameObject)Instantiate(towerOne, transform.position, transform.rotation);
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
        if (GUI.Button(buttons, "Tower 2 - 45 gold"))
        {
            if (money >= 45)
            {
                towerAux = (GameObject)Instantiate(towerTwo, transform.position, transform.rotation);
                text = 0;
            }

        }
    }
}
