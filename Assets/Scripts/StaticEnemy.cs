using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int damage;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform canonEnemy;
    private RaycastHit2D attention;
    private bool isAttention;
    [SerializeField] float coolDownFire = 2f;
    private Animator animation;
    private float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        IsFire();
        IsDeath();
    }

    private void ChasePlayer()
    {
        if (transform.localScale.x == -1f)
        {
            attention = Physics2D.Raycast(transform.position, Vector2.right, 7f, LayerMask.GetMask("Player"));
            Debug.DrawRay(transform.position, Vector2.right * 11f, Color.red);
        }
        else
        {
            attention = Physics2D.Raycast(transform.position, Vector2.left, 7f, LayerMask.GetMask("Player"));
            Debug.DrawRay(transform.position, Vector2.left * 11f, Color.red);
        }
        isAttention = attention.collider != null;
    }

    private void IsFire()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= coolDownFire && isAttention)
        {
            if(transform.localScale.x == -1f)
            {
                Instantiate(bullet, canonEnemy.position, Quaternion.identity);
            }
            else
            {
                Instantiate(bullet, canonEnemy.position, Quaternion.identity);
                canonEnemy.localScale.Set(-1, 1, 1);
            }
            tiempo = 0;
        }
    }

    private void IsDeath()
    {
        if (life <= 0)
        {
            animation.SetBool("isDeath", true);
        }
    }
}