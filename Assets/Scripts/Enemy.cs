using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().SetLife(character.GetComponent<Enemy>().GetDamage());
        }
    }
}
