using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite nightBackground;
    public Sprite dayBackground;

    public void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.fiveLevelsCompleted == true) //if the five levels are completed the background changes to a "blue sky" one, if not, it keeps the "night" one.
        {
            backgroundImage.sprite = dayBackground; 
        }
        else
        {
            backgroundImage.sprite = nightBackground;
        }
    }


    public void SetSceneToLoad(int levelToPlay)
    {
        GameManager.Instance.selectedLevel = levelToPlay;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(GameManager.Instance.selectedLevel);
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
