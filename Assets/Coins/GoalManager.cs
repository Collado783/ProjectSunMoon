using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoalManager : MonoBehaviour
{

    public Sprite[] metaSprites;
    public SpriteRenderer spriteRenderer;
    public int currentCoins;
    public int maxCoins;
    public static GoalManager goalManager { get; private set; }
    void Awake()
    {
        if (goalManager != null)
        {
            Destroy(gameObject);
            return;
        }
        goalManager = this;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentCoins = 0;
        spriteRenderer.sprite = metaSprites[0];

    }

    public void AddCoin()
    {
        currentCoins++;
        UpdateSprite();

    }
    private void UpdateSprite()
    {
        spriteRenderer.sprite = metaSprites[currentCoins];
       
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<Char2DMover>();


        if (player && currentCoins == 12)
        {
            GameManager.Instance.UnlockLevels(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadSceneAsync(SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/MainMenu.unity"));

            
        }

    }

}
    
   



   
    
