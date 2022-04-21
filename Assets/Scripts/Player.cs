using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    Animator animation;
    private bool isGrounded;
    AudioSource audioDeath;
    public GameObject Bullet;
    public Transform CanonPlayer;
    public Bullet direction;
    [SerializeField] float speed;
    [SerializeField] float jumpImpulse;
    [SerializeField] int firerate;
    [SerializeField] int life;
    [SerializeField] int damage;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        audioDeath = GetComponent<AudioSource>();
        if (audioDeath == null) audioDeath = gameObject.AddComponent<AudioSource>();
    }


    // Update is called once per frame
        void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * 1.2f, Color.red);
        isGrounded = ray.collider != null;
        IsJumping();
        IsFire();
        IsDeath();
    }

    private void IsJumping()
    {
        if (isGrounded && !animation.GetBool("isJumping") && !animation.GetBool("isFire"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
                animation.SetBool("isJumping", true);
            }
        }
        else
        {
            animation.SetBool("isJumping", false);
        }
        if (body.velocity.y < 0 && !isGrounded)
        {
            animation.SetBool("isFalling", true);
        }
        else
        {
            animation.SetBool("isFalling", false);
        }
    }

    private void IsDeath()
    {
        if (life <= 0)
        {
            animation.SetBool("isDeath", true);
            if (animation.GetBool("isDeath"))
            {
                Time.timeScale = 0f;
                StartCoroutine(Restart());
            }
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(1f);

        audioDeath.PlayOneShot(Resources.Load<AudioClip>("death"), 0.1f);

        yield return new WaitForSecondsRealtime(1f);

        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        float dirH = Input.GetAxis("Horizontal");

        if (dirH != 0)
        {
            animation.SetBool("isRunning", true);
            if (dirH < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else
        {
            animation.SetBool("isRunning", false);
        }

        body.velocity = new Vector2(dirH * speed, body.velocity.y);
    }

    private void IsFire()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            animation.SetBool("isFire", true);
            Instantiate(Bullet, CanonPlayer.position, Quaternion.identity);
        }
        else
        {
            animation.SetBool("isFire", false);
        }
    }

    public void SetLife(int enemyDamage)
    {
        life -= enemyDamage;
    }
}
