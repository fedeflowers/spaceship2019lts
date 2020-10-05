using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public float speed;
    //public GameObject explosion;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("lato Destro");
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            proj.transform.Rotate(0f, 0f, -90f);
            SoundManager.PlaySound("allyGun");
        }
        if (Input.touchCount> 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                if ((Input.touches[i].position.x > Screen.width / 2) && Input.touches[i].phase == TouchPhase.Began)
                {
                    Debug.Log("lato Destro");
                    GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                    proj.transform.Rotate(0f, 0f, -90f);
                    SoundManager.PlaySound("allyGun");

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