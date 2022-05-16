using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManagement : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int currentExp;
    public int lvlUpExp = 400;

    Dictionary<int, int> lvlManager = new Dictionary<int, int>();

    public int lvlPlayer = 1;

    public HealthBar healthBar;
    public ExperienceBar experienceBar;

    void Start()
    {
        currentHealth = maxHealth;
        currentExp = 0;

        CreateLvlManager();
        experienceBar.SetExp(currentExp);
        experienceBar.SetLvlText(lvlPlayer);
        

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealthText(maxHealth, maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            GetExperience(20, lvlPlayer);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        healthBar.SetHealthText(currentHealth, maxHealth);
    }

    void GetExperience(int experience, int lvlplay)
    {
        currentExp += experience;
        experienceBar.SetMaxExp(lvlManager[lvlplay]);
        if (currentExp >= lvlManager[lvlplay])
        {
            currentExp = 0;
            lvlPlayer += 1;
        }
        experienceBar.SetExp(currentExp);
        experienceBar.SetLvlText(lvlPlayer);
    }

    void CreateLvlManager()
    {
        for (int i = 0; i <= 50; i++)
        {
            lvlUpExp = lvlUpExp + 100;
            lvlManager.Add(i, lvlUpExp);
        }
    }


}
