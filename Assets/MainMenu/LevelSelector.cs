using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;

    public void Start()
    {
        PlayerPrefs.DeleteKey("UnlockedLevel");
        PlayerPrefs.Save();
    }
    public void Awake()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevel", 1);
        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevels; i++)
        {
            buttons[i].interactable = true;
        }

    }

    


}
