using UnityEngine;
using System.Collections;

public class GoblinWave : MonoBehaviour
{
    public Transform enemyPath;
    public GameObject enemy;
    private Object enemyAux;
    private EnemyBehaviour enemyBehaviour;
    private bool newWave;
    private float respawnTime;
    private int enemiesPerWave;
    private int generatedEnemies;
    private int enemyLife;
    private int enemySpeed;
    public int enemiesAlive;
    private int currenWave;
    private int challengeMod;

    // Use this for initialization
    void Start()
    {
        enemiesPerWave = 10;
        respawnTime = 0;
        currenWave = 0;
        enemiesAlive = 10;
        generatedEnemies = 0;
        challengeMod = 0;
        enemyLife = 30;
        enemySpeed = 5;
        newWave = true; 		
    }

    // Update is called once per frame
    void Update()
    {
        if (newWave)
        {
            respawnTime += Time.deltaTime;
            if (respawnTime > 4)
            {
                respawnTime = 0;
                if (enemiesPerWave > generatedEnemies)
                {
                    enemyAux = Instantiate(enemy, transform.position, transform.rotation);
                    enemyBehaviour.path = enemyPath;
                    enemyBehaviour.currentLife = enemyLife;
                    enemyBehaviour.life = enemyLife;
                    enemyBehaviour.speed = enemySpeed;
                    generatedEnemies++;
                }
                else
                {
                    newWave = false;
                }
            }
        }
        else
        {
            if (enemiesAlive == 0)
            {
                newWave = true;
                challengeMod++;
                if (challengeMod == 1)
                {
                    enemyLife = enemyLife + 5;
                }
                if (challengeMod == 2)
                {
                    enemyLife = enemyLife - 5;
                    if (enemySpeed < 50)
                    {
                        enemySpeed++;
                    }
                }
                if (challengeMod == 3)
                {
                    enemyLife = enemyLife + 5;
                    challengeMod = 0;
                    if (enemiesPerWave < 50)
                    {
                        enemiesPerWave += 3;
                    }
                }
                generatedEnemies = 0;
                enemiesAlive = enemiesPerWave;
                currenWave++;
            }
        }
    }
}
