using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    bool isActive = false;
    public static bool isPausePanelActive = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActive == false)
            {
                pausePanel.gameObject.SetActive(true);
                isActive = true;
                Time.timeScale = 0;
                isPausePanelActive = true;

            }
            else
            {
                pausePanel.gameObject.SetActive(false);
                isActive = false;
                Time.timeScale = 1;
                isPausePanelActive = false;
            }



        }
    }




}
