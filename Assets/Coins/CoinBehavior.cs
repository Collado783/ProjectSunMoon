using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour 
{
    public int coinCount;
    public Text coinText;
    public GameObject goalCoin;
    public int maxCoins = 12;

    private void Update()
    {
        coinText.text = coinCount.ToString();

        if (coinCount == maxCoins) {}


    }
}
