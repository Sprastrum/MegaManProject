using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D collider;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(+speed, 0);
        Destroy(gameObject, 5f);
    }

    public void SetDirection(float direction)
    {
        speed *= direction;
    }
}
