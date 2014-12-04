using UnityEngine;
using System.Collections;

public class TowerBehaviour : MonoBehaviour
{
    int range;
    int attackPower;
    float attackSpeed;
    float time;
    float distance;
    GameObject[] enemies;
    GameObject targetedEnemies;
    GameObject enemy;
    bool findEnemy;
    Transform target;
    EnemyBehaviour enemyBehaviour;

    void Start()
    {
        range = 30;
        attackPower = 10;
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
            target = transform.GetChild(1);
            Quaternion direction;
            direction = Quaternion.LookRotation( enemy.transform.position -transform.position);
            target.localEulerAngles = new Vector3(target.rotation.x, direction.eulerAngles.y, target.rotation.z);

            if (time > attackSpeed)
            {
                enemyBehaviour = (EnemyBehaviour)enemy.GetComponent("EnemyBehaviour");
                enemyBehaviour.currentLife -= attackPower;
                Transform cannon;
                cannon = target.GetChild(0);
                cannon.Rotate(Vector3.right * Time.deltaTime);
                time = 0;
            }
        }
    }
}