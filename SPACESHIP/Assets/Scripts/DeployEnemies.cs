using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class DeployEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject enemyPrefab;

    public GameObject[] bosses;
    private GameObject boss;

    public float respawnTime = 1.0f;
    public float respawnTimeBoss = 10f;

    private GameObject EnemiesGenerationPoint;
    private GameObject enemyPoint;



    // Use this for initialization
    void Start()
    {
        EnemiesGenerationPoint = GameObject.Find("GenerationPoint");
        //enemyPoint = GameObject.FindGameObjectWithTag("EnemyPoint");

        StartCoroutine(enemyWave());
        StartCoroutine(bossWave());

    }
    private void spawnEnemy()
    {
        enemyPrefab = enemies[(int)Random.Range(0, enemies.Length)];
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.transform.position = new Vector3(EnemiesGenerationPoint.transform.position.x, Random.Range(-5.5f, 7), EnemiesGenerationPoint.transform.position.z);
        UnityEngine.Debug.Log("spawn ENEMY");
    }

    private void spawnBoss()
    {
        boss = bosses[(int)Random.Range(0, bosses.Length)];
        GameObject a = Instantiate(boss) as GameObject;
        a.transform.position = new Vector3(EnemiesGenerationPoint.transform.position.x, Random.Range(-5.5f, 7), EnemiesGenerationPoint.transform.position.z);
        UnityEngine.Debug.Log("spawn BOSS");
    }
    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime * Random.Range(1f, 1.5f));
            spawnEnemy();
            
        }
    }

    IEnumerator bossWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTimeBoss * Random.Range(1f, 1.5f));
            spawnBoss();

        }
    }
}