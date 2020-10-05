using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text hiscoreText;
    private bool maggiore1000 = true;

    public static float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public  bool scoreIncreasing;
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;

            if (PlayerPrefs.HasKey("HighScore") == true)
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
            //quando starti hai + 10
        if (PlayerPrefs.HasKey("Coins")== true)
        {
            coins = PlayerPrefs.GetInt("Coins");
            coins += 5;
        }
        else
        {
            coins += 5;
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond* Time.deltaTime;
            
        }

        

        if (scoreCount >= hiScoreCount)
        {
            hiScoreCount = scoreCount;
        }
        //da fare giusto
        if (scoreCount%1000<100 && maggiore1000 == true && scoreCount >100)
        {
            maggiore1000 = false;
            coins += 30;
            
            UnityEngine.Debug.Log(">1000");
        }

        if(scoreCount % 1000 > 100 && maggiore1000 == false)
        {
            maggiore1000 = true;
        }

        scoreText.text =  "" + Mathf.Round(scoreCount);
        hiscoreText.text = "" + Mathf.Round(hiScoreCount);
        PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        PlayerPrefs.SetInt("Coins", coins);
    }
    //utile
    /*
    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }*/
}

