using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public GameObject explosion;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Death")
        {
            Debug.Log("hit detected");
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            SoundManager.PlaySound("explosion");
            this.gameObject.SetActive(false);
            Invoke("restart", 2f);
        }
            
    }

    void restart()
    {
        SceneManager.LoadScene("GameOver");

    }
}
