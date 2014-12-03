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
    GameObject targetedEnemys;
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
        enemies = GameObject.FindGameObjectsWithTag("Skeleton");

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
            target = transform.GetChild(0);

            Quaternion Rotacao;
            Rotacao = Quaternion.LookRotation(transform.position - enemy.transform.position);

            target.localEulerAngles = new Vector3(0, Rotacao.eulerAngles.y, 0);

            if (time > attackSpeed)
            {
                enemyBehaviour = (EnemyBehaviour)enemy.GetComponent("EnemyBehaviour");
                enemyBehaviour.currentLife -= attackPower;

                Transform cannon;
                cannon = target.GetChild(0);
                cannon.Rotate(0, 0, 360 * Time.deltaTime);
                time = 0;
            }
        }
    }
}