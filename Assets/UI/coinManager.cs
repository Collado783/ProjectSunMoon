using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class coinManager : MonoBehaviour 
{
    public Text coinsText;
    public int coinsIndex = 0;
    public static coinManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinsText.text = coinsIndex.ToString() + "/12";
    }
    
    public void AddPoint()
    {
        coinsIndex += 1;
        coinsText.text = coinsIndex.ToString() + "/12";
        
    }
}
