using UnityEngine;

public class CoinPlayer : MonoBehaviour
{

    public float StartingCoins = 0;
    private float Coins;
   
   


    public delegate void CoinsChangedHandler(float newCoins, float ammountChanged);
    public event CoinsChangedHandler OnCoinsChanged;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Coins = StartingCoins;
       

    }

    // Update is called once per frame
    void Update()
    {

    }

   
 

  

    public void AddCoins(float coinsToAdd)
    {

        Coins += coinsToAdd;
        OnCoinsChanged?.Invoke(Coins, coinsToAdd);

       
    }
}
