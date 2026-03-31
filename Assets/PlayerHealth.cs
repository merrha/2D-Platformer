using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    private float Health;
    private bool CanRecieveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newHealth,float ammountChanged);
    public event HealthChangedHandler OnHealthChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
       
        Debug.Log(Health);

    }
    private void ResetInvincibility()
    {
        CanRecieveDamage = true;
       
    }

    IEnumerator InvincibilityTimer(float time,Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
        Debug.Log(CanRecieveDamage);
    }

    public void AddHealth(float healthToAdd)
    { 
    
        Health += healthToAdd;
        OnHealthChanged?.Invoke(Health, healthToAdd);
    }
}

