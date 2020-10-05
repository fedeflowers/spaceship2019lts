using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Load_HighScore : MonoBehaviour
{
    //public TextMeshProUGUI textLoad;
    public Text textLoad;

    private float highscore;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetFloat("HighScore");
        }

        textLoad.text = "HighScore: " + Mathf.Round(highscore);

    }

    // Update is called once per frame
    void Update()
    {

    }
}