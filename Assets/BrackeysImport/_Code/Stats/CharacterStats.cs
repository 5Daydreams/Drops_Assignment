using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat maxHealth;
    public int currentHealth { get; private set; }
    
    public Stat damage;
    public Stat armour;

    private void Awake()
    {
        maxHealth.BaseValue = 100;
        currentHealth = maxHealth.BaseValue;
    }

    public void TakeDamage(int damage)
    {
        damage -= armour.BaseValue;

        if (damage <=0)
        {
            damage = 0;
        }


        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public virtual void Die()
    {
        Debug.Log("this object died : /");
    }
}
