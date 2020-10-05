using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip explosion;
    public static AudioClip enemyShot;
    public static AudioClip tastoClick;
    public static AudioClip allyGun;



    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

        explosion = Resources.Load<AudioClip>("explosion");
        enemyShot = Resources.Load<AudioClip>("enemyShot");
        tastoClick = Resources.Load<AudioClip>("tastoClick");
        allyGun = Resources.Load<AudioClip>("allyGun");



        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "explosion":
                audioSrc.PlayOneShot(explosion);
                break;
            case "enemyShot":
                audioSrc.PlayOneShot(enemyShot);
                break;
            case "tastoClick":
                audioSrc.PlayOneShot(tastoClick);
                break;
            case "allyGun":
                audioSrc.PlayOneShot(allyGun);
                break;
        }
    }
}
