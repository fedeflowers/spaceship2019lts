using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour
{
    //public float speed;
    //public GameObject explosion;
    public GameObject projectile;

    private Text ammosText;
    public static int ammos;
    // Start is called before the first frame update
    void Start()
    {
        ammos = 100;
        ammosText = GameObject.Find("Canvas/Image/ammoText").GetComponent<Text>();
        ammosText.text = ammos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && ammos >0)
        {
            Debug.Log("lato Destro");
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            proj.transform.Rotate(0f, 0f, -90f);
            SoundManager.PlaySound("allyGun");
            ammos -= 1;
            ammosText.text = ammos.ToString();
        }
        if (Input.touchCount> 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                if ((Input.touches[i].position.x > Screen.width / 2) && Input.touches[i].phase == TouchPhase.Began && ammos > 0)
                {
                    Debug.Log("lato Destro");
                    GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                    proj.transform.Rotate(0f, 0f, -90f);
                    SoundManager.PlaySound("allyGun");
                    ammos -= 1;
                    ammosText.text = ammos.ToString();

                } /*else if ((Input.touches[i].position.x < Screen.width / 2) && Input.touches[i].phase == TouchPhase.Began)
                    {
                    GameObject joystick = GameObject.Find("MobileSingleStickControl");
                    joystick.transform.Find("joystickBackground").position = Input.touches[i].position;
                    joystick.transform.Find("joystickForeground").position = Input.touches[i].position;

                }*/
            }
            
        }

    }

}