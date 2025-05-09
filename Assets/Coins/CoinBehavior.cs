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

    protected void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<Char2DMover>();

        if (player)
        {
            Destroy(gameObject);
            coinManager.instance.AddPoint();
        }


    }
}
