using UnityEngine;
using System.Collections;

public class TowerCreate : MonoBehaviour {

    public Camera MainCamera;

    public int Preco;
    public string TextoTag;
    public bool PodeCriar;

    public GameObject TorreFinal, TorreFinalAux;
    Transform Filhos;
    Touch Touch;
    Vector3 TouchLoc;

    public MenuCompra MenuCompraAux;

    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main;
        PodeCriar = false;
        MenuCompraAux = (MenuCompra)GameObject.Find("Player").GetComponent("MenuCompra");
    }

    // Update is called once per frame
    void Update()
    {
        MenuCompraAux.IndiceTexto = 0;
	    Ray raio = MainCamera.ScreenPointToRay(Input.mousePosition);
	    RaycastHit Colisor;

	    Filhos = transform.GetChild(0);
	    Filhos.renderer.material.color = Color.red;

	    if (Physics.Raycast(raio, out Colisor, Mathf.Infinity)){
            
            SetTransform(Colisor.point.x, 8+transform.lossyScale.y/2, Colisor.point.z);

		    PodeCriar=true;
		    int qntFilhos  = transform.childCount;
		    int i;

		    for (i=0;i<qntFilhos;i++){
			    Transform filho = transform.GetChild(i);
			    if (Physics.Raycast(filho.position,-Vector3.up, out Colisor,Mathf.Infinity)){
				    if (Colisor.point.y<7.9 || Colisor.point.y>8.1){ 
				        PodeCriar=false;
			            break;
			        }
			    }
		    }
		    if(PodeCriar){
			    Filhos.renderer.material.color = Color.blue;

			    if(Input.touchCount> 0 || Input.GetMouseButtonDown(0)){
				    TorreFinalAux = (GameObject)Instantiate(TorreFinal,transform.position,Quaternion.identity);
                    MenuCompraAux = (MenuCompra)GameObject.Find("Player").GetComponent("MenuCompra");
                    MenuCompraAux.Dinheiro -= Preco;
				    TorreFinalAux.tag = TextoTag;
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
