using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;

    public void Start()
    {
        int unlockedLvls = GameManager.Instance.unlockedLevels;
        
        for (int i = 0; i < buttons.Length; i++)  
        {
            buttons[i].interactable = false;  //desactivar els botons l'index dels quals sigui menor als nivells desbloquejats

        }
        for (int i = 0; i < unlockedLvls; i++)
        {
            buttons[i].interactable = true;

        }

    }

    
    


}
