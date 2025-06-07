using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void BackToMenu()
    {
         SceneManager.LoadSceneAsync(SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/MainMenu.unity"));
    }
    


}
