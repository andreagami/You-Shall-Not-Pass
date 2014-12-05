using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public Transform path;
    private Vector3 distance;
    private Quaternion enemyRotation;
    private GoblinWave goblinKill;
    private TowerLifeBar towerLife;
    private float bound;
    private float rotation;
    private float rotationAux;
    public int speed;
    public float currentLife;
    public float life;
    //test
    // Use this for initialization
    void Start()
    {
        rotation = transform.rotation.eulerAngles.y;
        speed = 10;
        life = 30;
        currentLife = 30;
        towerLife = (TowerLifeBar) GameObject.Find("TowerLife").GetComponent("TowerLifeBar");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLife <= 0)
        {
            //animation.Play("death");
            //goblinKill.enemiesAlive--;
            //Wait();
            Destroy(gameObject);
        }
        if (path.childCount > 0)
        {
            distance = transform.position - path.position;
            bound = Vector3.Distance(transform.position, path.position);
            if (bound < 3)
            {
                path = path.GetChild(0);
                if(path.childCount <= 0)
                {
                    towerLife.currentLife -= this.currentLife;
                    Destroy(gameObject);
                }
            }
            else
            {
                enemyRotation = Quaternion.LookRotation(distance);
                rotationAux = transform.localEulerAngles.y - enemyRotation.eulerAngles.y - 180;
                if (rotationAux < 0) rotationAux += 360;
                if (rotationAux > 360) rotationAux -= 360;
                if (rotationAux > 10 && rotationAux < 180) transform.localEulerAngles -= new Vector3(0, 145 * Time.deltaTime, 0);
                if (rotationAux > 180 && rotationAux < 350) transform.localEulerAngles += new Vector3(0, 145 * Time.deltaTime, 0);
                if (rotationAux < 10 || rotationAux > 350)
                {
                    transform.localEulerAngles = new Vector3(0, enemyRotation.eulerAngles.y - 180, 0);
                    transform.Translate(0, 0, speed * Time.deltaTime);
                    animation.Play("run");
                }
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
    }
}
