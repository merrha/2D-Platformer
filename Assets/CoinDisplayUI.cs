using TMPro;
using UnityEngine;

public class CoinDisplayUI : MonoBehaviour
{
    public TextMeshProUGUI CoinsText;
    public CoinPlayer coinPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       coinPlayer.OnCoinsChanged += OnCoinsChanged;
        


    }

   

    public void OnCoinsChanged(float newCoins, float ammountChanged)
    {
        //Debug.Log("On Health Changed Event");
        CoinsText.text = newCoins.ToString();
    }



}
