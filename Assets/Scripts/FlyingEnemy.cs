using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemy : MonoBehaviour
{
    private AIPath path;
    private Animator animation;
    private float timer;
    [SerializeField] int life;
    [SerializeField] int damage;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<AIPath>();
        animation = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        IsDeath();
    }

    private void FixedUpdate()
    {
        if (transform.position.x < 0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    void ChasePlayer()
    {
        Collider2D atention = Physics2D.OverlapCircle(transform.position, 7f, LayerMask.GetMask("Player"));

        if(atention != null && !animation.GetBool("isDeath"))
        {
            path.isStopped = false;
        }
        else
        {
            path.isStopped = true;
        }
    }

    private void IsDeath()
    {
        if (life <= 0)
        {
            animation.SetBool("isDeath", true);
            Destroy(gameObject, 0.9f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !animation.GetBool("isDeath"))
        {
            collision.GetComponent<Player>().SetLife(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 8f);
    }
}
