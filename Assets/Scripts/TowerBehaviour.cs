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
    Transform towerBase;
    Transform cannon;
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
            cannon = towerBase.GetChild(1);
            direction = Quaternion.LookRotation(transform.position - enemy.transform.position);
            cannon.localEulerAngles = new Vector3(towerBase.rotation.x, direction.eulerAngles.y - 180, towerBase.rotation.z);

            if (time > attackSpeed)
            {
                enemyBehaviour = (EnemyBehaviour)enemy.GetComponent("EnemyBehaviour");
                enemyBehaviour.currentLife -= attackPower;
                cannon.transform.Rotate(Vector3.right * Time.deltaTime);
                time = 0;
            }
        }
    }
}