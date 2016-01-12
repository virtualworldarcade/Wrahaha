﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;

    public Image damageImage;

    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    bool isDead;
    bool damaged;


    void Awake ()
    {
        currentHealth = startingHealth;
    }


    void Update ()
    {
        //if(damaged)
        //{
        //    damageImage.color = flashColour;
        //}
        //else
        //{
        //    damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        //}
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

   
		Debug.Log("player attacked! HP: " + currentHealth.ToString());
        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
		Debug.Log("dead.. restarting..");
		RestartLevel();

    }


    public void RestartLevel ()
    {
        Application.LoadLevel (Application.loadedLevel);
    }
}
