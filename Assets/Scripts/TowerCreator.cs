using UnityEngine;
using System.Collections;

public class TowerCreator : MonoBehaviour {

    public Camera mainCamera;
    public bool canCreate;
    public GameObject tower;
    public GameObject towerAux;
    public string tag;
    public Transform child;
    public int price;
    public BuyingMenu priceAux;
    public float lastClickTime;
    public float catchTime;

	void Start () {
        mainCamera = Camera.main;
        canCreate = false;        
        priceAux = (BuyingMenu) GameObject.Find("Player").GetComponent("BuyingMenu");
	}
	
	// Update is called once per frame
	void Update (){
        priceAux.text = 0;
        Ray radius  = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit collision ;
        child = transform.GetChild(1);
        if (Physics.Raycast(radius,out collision,Mathf.Infinity))
        {
            transform.position = new Vector3(collision.point.x, 9f+transform.lossyScale.y/2 ,collision.point.z);
            canCreate=true;
            int childCount = transform.childCount;
            int i;
            for (i=0;i<childCount;i++)
            {
    
                Transform childObj = transform.GetChild(i);
                if (Physics.Raycast(childObj.position, -Vector3.up, out collision, Mathf.Infinity))
                {
    
                    if (collision.point.y>-15.9f || collision.point.y<-16.1f)
                    { 
                        canCreate=false;
                        break;
                    }
    
                }

            }
            if(canCreate)
            {
                lastClickTime = 0;
                catchTime = 25;
                if (Input.GetMouseButtonDown(0))
                {
                    if (Time.time - lastClickTime < catchTime)
                    {
                        Vector3 instancePos = new Vector3(transform.position.x, 16.0f, transform.position.z);
                        towerAux = (GameObject)Instantiate(tower, transform.position, transform.rotation);
                        priceAux = (BuyingMenu)GameObject.Find("Player").GetComponent("BuyingMenu");
                        priceAux.money -= price;
                        Destroy(gameObject);
                    }
                    
                }
            }

        }
	}
}
