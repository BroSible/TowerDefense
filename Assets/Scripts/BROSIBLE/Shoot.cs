using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    GameObject bulletRef;
    public GameObject bullet;
    public static float timeBetweenShots = 1.5f; 
    public float timeSinceLastShot = 0f; 
    Animator animator;
    public static bool isShooting = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        bulletRef = Resources.Load<GameObject>("Princess sphere");
    }

 
    void FixedUpdate()
    {
        timeSinceLastShot += Time.deltaTime;
            if(Input.GetButton("Fire1"))
            {
                if(timeSinceLastShot >= timeBetweenShots)
                {
                    Instantiate(bullet,shootingPoint.position,transform.rotation);
                    timeSinceLastShot = 0;
                }
            }
    }
}
