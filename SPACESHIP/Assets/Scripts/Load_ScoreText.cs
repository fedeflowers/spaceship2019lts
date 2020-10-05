using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Load_ScoreText : MonoBehaviour
{
    public Text textLoad;
    // Start is called before the first frame update
    void Start()
    {
        
        textLoad.text = "Score: " + Mathf.Round(ScoreManager.scoreCount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
