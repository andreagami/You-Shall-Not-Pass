using UnityEngine;
using System.Collections;

public class TowerCreate : MonoBehaviour {

    private Transform child;
    public Camera mainCamera;
    public GameObject tower;
    public GameObject towerAux;
    public BuyingMenu buyingMenu;
    public int price;
    public string text;
    public bool create;
    private float lastClickTime;
    float catchTime;
    

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
        create = false;
        buyingMenu = (BuyingMenu)GameObject.Find("Player").GetComponent("BuyingMenu");
    }

    // Update is called once per frame
    void Update()
    {
        buyingMenu.text = 0;
	    Ray radius = mainCamera.ScreenPointToRay(Input.mousePosition);
	    RaycastHit collision;

	    child = transform.GetChild(0);
	    if (Physics.Raycast(radius, out collision, Mathf.Infinity)){
            
            SetTransform(collision.point.x, 9+transform.lossyScale.y/2, collision.point.z);

		    create=true;
		    int qntFilhos  = transform.childCount;
		    int i;

		    for (i=0;i<qntFilhos;i++){
			    Transform currentChild = transform.GetChild(i);
			    if (Physics.Raycast(currentChild.position,-Vector3.up, out collision,Mathf.Infinity)){
				    if (collision.point.y<8.9f || collision.point.y>9.1f){ 
				        create=false;
			            break;
			        }
			    }
		    }

		    if(create){
                lastClickTime = 0;
                catchTime = 25;
			    if(Input.GetMouseButtonDown(0)){
                    if(Time.time-lastClickTime<catchTime)
                    {
                        tower = this.gameObject;
                        towerAux = (GameObject)Instantiate(tower, transform.position, transform.rotation);
                        buyingMenu = (BuyingMenu)GameObject.Find("Player").GetComponent("BuyingMenu");
                        buyingMenu.money -= price;
                        towerAux.tag = text;
                        Destroy(gameObject);
                    }
			    }
		    }
	    }
    }

    void SetTransform(float x, float y, float z)
    {
        transform.position = new Vector3(x, y, z);
    }
}
