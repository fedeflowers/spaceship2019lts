using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiatePlayer : MonoBehaviour
{
    public Transform[] prefabs;
    private int index = 0;
    void Start()
    {
        if (PlayerPrefs.HasKey("prefabToInstantiateIndex"))
        {
            index = PlayerPrefs.GetInt("prefabToInstantiateIndex");

        }
        Instantiate(prefabs[index], new Vector3(0, 0, 0), Quaternion.identity).transform.Rotate(0f, 0f, 90f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
