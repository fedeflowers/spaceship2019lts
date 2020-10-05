using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroids : MonoBehaviour
{
    public GameObject[] asteroids;
    private GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private GameObject AsteroidsGenerationPoint;

    // Use this for initialization
    void Start()
    {
        AsteroidsGenerationPoint = GameObject.Find("GenerationPoint");

        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        asteroidPrefab = asteroids[(int) Random.Range(0,asteroids.Length)];
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.AddComponent<Asteroid>();
        a.transform.position = new Vector3(AsteroidsGenerationPoint.transform.position.x, Random.Range(-5.5f,7), AsteroidsGenerationPoint.transform.position.z);
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime * Random.Range(0.2f,0.8f));
            spawnEnemy();
        }
    }
}