using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    bool isActive = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActive == false)
            {
                pausePanel.gameObject.SetActive(true);
                isActive = true;
            }
            else
            {
                pausePanel.gameObject.SetActive(false);
                isActive = false;
            }



        }

    }
}
