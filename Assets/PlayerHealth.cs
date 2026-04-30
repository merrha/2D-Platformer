using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    private float Health;
    private bool CanRecieveDamage = true;
    public float invincibilityTimer = 2;
    public string sceneName;

   
    public delegate void HealthChangedHandler(float newHealth,float ammountChanged);
    public event HealthChangedHandler OnHealthChanged;
    public delegate void HealthInitHandler  (float newHealth);
    public event HealthInitHandler OnHealthInit;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
        OnHealthInit?.Invoke(Health);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void AddDamage(float damage)
    {
      
        if (CanRecieveDamage) 
        {
            Health -= damage;
            OnHealthChanged?.Invoke(Health, -damage);
            CanRecieveDamage=false; 
            StartCoroutine(InvincibilityTimer(invincibilityTimer,ResetInvincibility)); 
        }
       
       

    }
    private void ResetInvincibility()
    {
        CanRecieveDamage = true;
       
    }

    IEnumerator InvincibilityTimer(float time,Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
        
    }

    public void AddHealth(float healthToAdd)
    { 
    
        Health += healthToAdd;
        OnHealthChanged?.Invoke(Health, healthToAdd);
    }
}

