using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allyProjectile : MonoBehaviour
{
    public float speed;
    public int damage = 10;
    public GameObject explosion;
    Rigidbody2D rb;
    private Enemy _enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DestroyProjectile();
            other.GetComponent<Enemy>().currentHealth -= damage;
        }
        /*if (other.CompareTag("Bubbled"))
            DestroyProjectile();*/

    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.position = transform.position;
        SoundManager.PlaySound("explosion");
    }
}
