using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;
    [SerializeField] private AudioClip levelSound;
    [SerializeField] private AudioSource sound;
    public void Start()
    {
        int unlockedLvls = GameManager.Instance.unlockedLevels;
        
        
        for (int i = 0; i < buttons.Length; i++)  
        {
            buttons[i].interactable = false;  //deactivate the buttons whose index are less than the unlocked levels 

        }
        for (int i = 0; i < unlockedLvls; i++)
        {
            buttons[i].interactable = true;
            buttons[i].onClick.AddListener(PlayClickSound);
        }

    }

    public void PlayClickSound()
    {
        sound.PlayOneShot(levelSound);
    }
    


}
