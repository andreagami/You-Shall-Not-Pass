using UnityEngine;
using System.Collections;

public class TowerLifeBar : MonoBehaviour {

    private GameObject player;
    private Vector4 color;
    public float life;
    public float currentLife;
    private float barScale;

    // Use this for initialization
    void Start()
    {
        //RGB
        color.x = 0; //Red
        color.y = 1; //Green
        color.z = 0; //Blue

        life = 300;
        currentLife = 300;

        barScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        color.x = 1 - (currentLife / life);
        color.y = currentLife / life;
        transform.renderer.material.color = color;
        transform.localScale = new Vector3(barScale * (currentLife / life), 0.09f, 0.09f);

        if (currentLife <= 0)
        {
            Application.LoadLevel("GameOver");
        }
    }
}
