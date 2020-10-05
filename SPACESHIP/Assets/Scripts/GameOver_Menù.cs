using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Menù : MonoBehaviour
{
    
   

    public void Restart()
    {


        SoundManager.PlaySound("tastoClick");
        SceneManager.LoadScene("MainScene");
        Enemy.bossDeathCounts = 0;




    }
    public void Shop()
    {
        SoundManager.PlaySound("tastoClick");
        SceneManager.LoadScene("ShopScene");
        Enemy.bossDeathCounts = 0;
    }


    public void QuitGame()
    {
        SoundManager.PlaySound("tastoClick");
        Application.Quit();
        Debug.Log("Quit!");
    }

}
