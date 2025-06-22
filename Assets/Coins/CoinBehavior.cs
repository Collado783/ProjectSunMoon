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
    [SerializeField] private AudioClip coinSound;


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
    
    protected void OnTriggerEnter2D(Collider2D collision)
    {

        var player = collision.GetComponent<Char2DMover>();


        if (player)
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position, 1000000f);
            Destroy(gameObject);
            coinManager.instance.AddPoint();
            
            GoalManager.goalManager.AddCoin();

        }

    }
    

}
