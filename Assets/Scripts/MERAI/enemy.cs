using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private float attackDistance;
    [SerializeField] private Transform rayCast;
    [SerializeField] private float rayCastLength;
    private Animator anim;
    private bool m_FacingRight = true;
    private bool chill;
    private float distance;
    private RaycastHit2D hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target.transform.position.x < 0)
        {
            if (m_FacingRight)
            {
                Flip();

            }
        }
        if (target.transform.position.x > 0)
        {
            if (!m_FacingRight)
            {
                Flip();

            }
        }

        hit = Physics2D.Raycast(rayCast.position, Vector2.right, rayCastLength, raycastMask);
        RaycastDebugger();
        EnemyLogic();
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
        }
        else if (attackDistance >= distance && !chill)
        {
            Attack();
     
        }
    }
    void Attack()
    {
        StartCoroutine(attacking());
    }
    IEnumerator attacking()
    {
        chill = true;
        anim.Play("attack_demon");
        yield return new WaitForSeconds(0.7f);
        anim.Play("idle_demon");
        yield return new WaitForSeconds(1f);
        chill = false;
    }
  

    private void Move()
    {
        if (target != null)
        {
            if(target.transform.position.x < 0)
            {
                if (m_FacingRight)
                {
                    Flip();

                }
            }
            if (target.transform.position.x > 0)
            {
                if (!m_FacingRight)
                {
                    Flip();

                }
            }
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            anim.Play("run_demon");
        }
        else
        {
            anim.Play("idle_demon");
        }

    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.right * rayCastLength, Color.green);
        }
    }
}
