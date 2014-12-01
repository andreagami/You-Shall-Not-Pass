using UnityEngine;
using System.Collections;

public class EnemyLifeBar : MonoBehaviour {

    private GameObject player;
    private Vector4 color;
    private EnemyBehaviour enemy;
    private float barScale;
    private float life;
    private float currentLife;

	// Use this for initialization
	void Start () {
        //RGB
        color.x = 0; //Red
        color.y = 1; //Green
        color.z = 0; //Blue

        enemy = (EnemyBehaviour)transform.parent.GetComponent("EnemyBehaviour");
        life = enemy.life;
        currentLife = enemy.currentLife;

        barScale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (!player)
        {
            player = GameObject.Find("Player");
        }
        else
        {
            transform.LookAt(player.transform);
            transform.renderer.material.color = color;
        }
        color.x = 1 - (currentLife / life);
        color.y = currentLife / life;
        transform.localScale = new Vector3(barScale * (currentLife / life), 0.09f, 0.09f);
        
	}
}
