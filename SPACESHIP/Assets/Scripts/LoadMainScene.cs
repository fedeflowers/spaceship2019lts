﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMain()
    {
        SoundManager.PlaySound("tastoClick");
        SceneManager.LoadScene("MainScene");
    }
}
