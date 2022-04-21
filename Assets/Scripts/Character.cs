using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int damage;
    Animator animation;


    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLife()
    {
        return life;
    }

    public void SetLife(int damage)
    {
        life -= damage;
    }

    public int GetDamage()
    {
        return damage;
    }
}

