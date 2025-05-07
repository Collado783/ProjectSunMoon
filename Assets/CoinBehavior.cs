using UnityEngine;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour 
{
    public int coinCount;
    public Text coinText;

    private void Update()
    {
        coinText.text = coinCount.ToString();
    }
}
