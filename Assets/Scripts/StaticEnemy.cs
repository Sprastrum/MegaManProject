using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int damage;
    public GameObject Bullet;
    public Transform CanonEnemy;
    private RaycastHit2D attention;
    private bool isAttention;
    private float coolDownFire = 0f;
    private Animator animation;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        Fire();
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
        Debug.Log(isAttention);
    }

    private void Fire()
    {
        if (isAttention && coolDownFire == 0f)
        {
            coolDownFire = 4f;
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
        else
        {
            coolDownFire -= Time.deltaTime;
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
