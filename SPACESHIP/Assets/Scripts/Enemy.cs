using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int Coins=0;
    public static int bossDeathCounts = 0;

    public bool boss = false;
    public float speed = 10.0f;
    private Rigidbody2D rb;
    public int maxHealth = 20;
    public int currentHealth;
    //public GameObject explosionEnemy; DA IMPLEMENTARE EXPLOSION PER L'ENEMY PER PROJ E PLAYER C'è GIà
    //public float stoppingDistance;
    //public float retreatDistance;
    public GameObject projectile;
    private bool startShooting = false;
    public HealthBar healthBar;


    private GameObject point;


    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
       /* if (PlayerPrefs.HasKey("Coins") == true)
        {
            //UnityEngine.Debug.Log("coinsprefs");
            Coins = PlayerPrefs.GetInt("Coins");
        }*/
        if(boss == true)
        {
            maxHealth += 20 * bossDeathCounts;
        }
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        //point = GameObject.FindGameObjectWithTag("EnemyPoint");
        // point.transform.position = new Vector3(point.transform.position.x, Random.Range(-5.5f, 7), point.transform.position.z);
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {/*
        if(Vector2.Distance(transform.position, point.transform.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, point.transform.position, speed * Time.deltaTime);
        }else if(Vector2.Distance(transform.position, point.transform.position) < stoppingDistance && Vector2.Distance(transform.position, point.transform.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }else if(Vector2.Distance(transform.position, point.transform.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, point.transform.position, -speed * Time.deltaTime);

        }*/

        //mettere startshooting a true

        if(currentHealth<= 0)
        {
            if(boss == true)
            {
               // Coins += 50;
                //PlayerPrefs.SetInt("Coins",Coins);
                bossDeathCounts++;
            }
            Destroy(this.gameObject);
        }
        healthBar.SetHealth(currentHealth);

        if (timeBtwShots <= 0 && startShooting == true)
        {
            GameObject proj =  Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            SoundManager.PlaySound("enemyShot");
            proj.transform.Rotate(0f, 0f, 90f);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stop")
        {
            startShooting = true;
            transform.gameObject.tag = "Enemy";
            rb.velocity = new Vector2(2.64f, 0);
        }

    }
}
