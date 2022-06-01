using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int damage;


    // Start is called before the first frame update
    void Start()
    {
        
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

    private void IsDeath()
    {
        if (character.GetLife() <= 0)
        {
            GetComponent<Animation>().SetBool("isDeath", true);
            if (GetComponent<Animation>().GetBool("isDeath"))
            {
                Time.timeScale = 0f;
            }
        }
    }
}

