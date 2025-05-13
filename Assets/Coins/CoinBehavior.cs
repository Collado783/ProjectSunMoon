using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour 
{
    public int coinCount=1;
    public Text coinText;
    public GameObject goalCoin;
    public Sprite[] goalSprites;
    public int maxCoins = 12;
    public  static CoinBehavior coinBehavior;
    private SpriteRenderer goalSpriteRenderer;
    
    
    private void Start()
    {


        if (goalCoin != null)
        {
            goalSpriteRenderer = goalCoin.GetComponent<SpriteRenderer>();
        }

    }
    private void Update()
    {

        if (coinText != null)
        {
            coinText.text = "Monedas: " + coinCount;
        }
        if (coinCount == maxCoins) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }


    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<Char2DMover>();


        if (player)
        {
           
            Destroy(gameObject);
            coinManager.instance.AddPoint();
            
            GoalManager.goalManager.AddCoin();

        }

    }
    

}
