using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{


   // public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stop")
        {
            Destroy(gameObject);
        }

    }
}
