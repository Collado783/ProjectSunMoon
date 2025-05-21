using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SetSceneToLoad(int sceme)
    { }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
     
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
