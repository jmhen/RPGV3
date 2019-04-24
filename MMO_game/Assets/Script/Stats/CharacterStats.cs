
using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set;}

    public Stats hp;
    public Stats mp;
    public Stats attack;
    public Stats defense;
    public Stats magicAttack;
    public Stats magicDefense;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage)
    {
        damage -= defense.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); //ensure it never go below zero

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

        //Die in some way
        //this method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }
}
