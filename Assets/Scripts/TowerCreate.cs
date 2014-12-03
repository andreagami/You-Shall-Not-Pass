using UnityEngine;
using System.Collections;

public class TowerCreate : MonoBehaviour {

    public Camera MainCamera;

    public int price;
    public string text;
    public bool create;

    public GameObject tower, towerAux;
    Transform child;
    Touch touch;
    Vector3 touchLoc;

    public BuyingMenu buyingMenu;

    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main;
        create = false;
        buyingMenu = (BuyingMenu)GameObject.Find("Player").GetComponent("BuyingMenu");
    }

    // Update is called once per frame
    void Update()
    {
        buyingMenu.text = 0;
	    Ray radius = MainCamera.ScreenPointToRay(Input.mousePosition);
	    RaycastHit collision;

	    child = transform.GetChild(0);
	    child.renderer.material.color = Color.red;

	    if (Physics.Raycast(radius, out collision, Mathf.Infinity)){
            
            SetTransform(collision.point.x, 8+transform.lossyScale.y/2, collision.point.z);

		    create=true;
		    int qntFilhos  = transform.childCount;
		    int i;

		    for (i=0;i<qntFilhos;i++){
			    Transform filho = transform.GetChild(i);
			    if (Physics.Raycast(filho.position,-Vector3.up, out collision,Mathf.Infinity)){
				    if (collision.point.y<7.9 || collision.point.y>8.1){ 
				        create=false;
			            break;
			        }
			    }
		    }
		    if(create){
			    child.renderer.material.color = Color.blue;

			    if(Input.touchCount> 0 || Input.GetMouseButtonDown(0)){
				    towerAux = (GameObject)Instantiate(tower,transform.position,Quaternion.identity);
                    buyingMenu = (BuyingMenu)GameObject.Find("Player").GetComponent("BuyingMenu");
                    buyingMenu.money -= price;
				    towerAux.tag = text;
				    Destroy(gameObject);
			    }
		    }
	    }
    }

    void SetTransform(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }
}
