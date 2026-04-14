using System;
using TMPro;
using UnityEngine;
using static PlayerHealth;

public class UIHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInit += onHealthInit;
       

    }

    private void onHealthInit(float newHealth)
    {
       healthText.text = newHealth.ToString();
    }

    public void OnHealthChanged(float newHealth, float ammountChanged)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();
    }
   


}
