using UnityEngine;
using System.Collections;

public class MenuCompra : MonoBehaviour {

    public Camera MainCamera;

    Rect RectMenu, RectBotoes;
    public GameObject Torre1, Torre2, AuxTorre;

    public int IndiceTexto, Dinheiro, PontosJogo;
    
    Transform AuxTorreP;

    //DestroyTorre AuxDestroiTorre;

	// Use this for initialization
	void Start () {
        IndiceTexto = 0;
        Dinheiro = 100;
        PontosJogo = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(1)){
		    Ray raio = MainCamera.ScreenPointToRay(Input.mousePosition);
		    RaycastHit Colisor;
		    IndiceTexto=1; 
		    if (Physics.Raycast(raio, out Colisor, Mathf.Infinity)){
			    if (Colisor.transform.tag=="Torre1"){
				    IndiceTexto=2;
				    AuxTorreP = Colisor.transform;
			    }
			    if (Colisor.transform.tag=="Torre2"){
				    IndiceTexto=3;
				    AuxTorreP = Colisor.transform;
			    }
			
			    //Destroy(transform);
		    }
		    RectMenu.x = Input.mousePosition.x;
		    RectMenu.y = -(Input.mousePosition.y-Screen.height);
		    RectMenu.height = Screen.height/5;
		    RectMenu.width = Screen.width/5;
		    if ((RectMenu.x+RectMenu.width)>Screen.width){
			    RectMenu.x -= (RectMenu.x+RectMenu.width-Screen.width);
		    }
		    if ((RectMenu.y+RectMenu.height)>Screen.height){
			    RectMenu.y -= (RectMenu.y+RectMenu.height-Screen.height);
		    }
	    }
	}

    void OnGUI()
    {
        GUI.color = Color.yellow;
        GUI.Label(new Rect(10, 10, 100, 50), "Gold: " + Dinheiro);
        GUI.Label(new Rect(10, 40, 100, 50), "Pontos: " + PontosJogo);

        if (IndiceTexto == 1)
        {
            GUI.Window(0, RectMenu, Torres, "Torres");
        }
    }

    private void Torres(int id)
    {
        RectBotoes.x = 10;
        RectBotoes.y = 20;
        RectBotoes.width = RectMenu.width - 20;
        RectBotoes.height = RectMenu.height / 2 - 12;
        if (Dinheiro >= 55)
        {
            GUI.color = Color.yellow;
        }
        else
        {
            GUI.color = Color.red;
        }
        if (GUI.Button(RectBotoes, "Torre 1 - 55 gold"))
        {
            if (Dinheiro >= 55)
            {
                AuxTorre = (GameObject)Instantiate(Torre1, transform.position, transform.rotation);
                IndiceTexto = 0;
            }
        }
        RectBotoes.y += RectMenu.height / 2 - 12;
        if (Dinheiro >= 45)
        {
            GUI.color = Color.yellow;
        }
        else
        {
            GUI.color = Color.red;
        }
        if (GUI.Button(RectBotoes, "Torre 2 - 45 gold"))
        {
            if (Dinheiro >= 45)
            {
                AuxTorre = (GameObject)Instantiate(Torre2, transform.position, transform.rotation);
                IndiceTexto = 0;
            }

        }
    }
}
