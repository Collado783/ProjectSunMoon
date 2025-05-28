using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SetSceneToLoad(int levelToPlay)
    {
        GameManager.Instance.selectedLevel = levelToPlay;
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(GameManager.Instance.selectedLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
