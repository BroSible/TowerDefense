using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bullet;
    public float timeBetweenShots = 1.5f;
    private float timeRemaining = 0f;
    private bool canShoot = true;
    public Text textReload;
    public Animator blackOut;
    public AudioSource attack;

    void Start()
    {
        textReload.text = "";
    }

    void Update()
    {
        if (canShoot)
        {
            blackOut.Play("Lightening");
            if (Input.GetButton("Fire1"))
            {
                ShootBullet();
            }

            else
            {
                textReload.text = ""; 
            }
        }
        else
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                blackOut.Play("Blackout");
                if (timeRemaining < 0) 
                {
                    timeRemaining = 0;
                }

            }
            else
            {
                canShoot = true;
            }
        }

        if (!canShoot)
        {
            textReload.text = timeRemaining.ToString("F1");
        }
    }

    void ShootBullet()
    {
        Instantiate(bullet, shootingPoint.position, transform.rotation);
        attack.Play();
        canShoot = false; 
        timeRemaining = timeBetweenShots; 
    }
}
