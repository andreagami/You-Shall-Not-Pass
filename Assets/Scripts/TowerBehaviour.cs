using UnityEngine;
using System.Collections;

public class TowerBehaviour : MonoBehaviour
{
    int range;
    int attackPower;
    float attackSpeed;
    float time;
    float distance;
    bool findEnemy;
    GameObject[] enemies;
    GameObject targetedEnemies;
    GameObject enemy;
    public GameObject shotEffect;
    Transform towerBase;
    Transform towerHead;
    Transform towerCannon;
    Transform towerBarrel;
    Transform enemyLifeBar;
    EnemyBehaviour enemyBehaviour;
    Quaternion direction;    

    void Start()
    {
        range = 30;
        attackPower = 5;
        attackSpeed = 1;
    }

    void Update()
    {
        time += Time.deltaTime;
        findEnemy = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject targetedEnemy in enemies)
        {
            distance = Vector3.Distance(targetedEnemy.transform.position, transform.position);
            if (distance < range)
            {
                enemy = targetedEnemy;
                findEnemy = true;
                break;
            }
        }

        if (findEnemy)
        {
            towerBase = transform.GetChild(0);
            towerHead = towerBase.GetChild(0);
            towerCannon = towerHead.GetChild(0);
            towerBarrel = towerCannon.GetChild(0);
            direction = Quaternion.LookRotation(transform.position - enemy.transform.position);
            towerHead.localEulerAngles = new Vector3(towerBase.rotation.x, direction.eulerAngles.y - 180, towerBase.rotation.z);

            if (time > attackSpeed)
            {
                enemyBehaviour = (EnemyBehaviour)enemy.GetComponent("EnemyBehaviour");
                enemyBehaviour.currentLife -= attackPower;
                towerHead.transform.Rotate(Vector3.right * Time.deltaTime);
                Instantiate(shotEffect, towerBarrel.position, towerBarrel.rotation);
                time = 0;
            }
        }
    }
}