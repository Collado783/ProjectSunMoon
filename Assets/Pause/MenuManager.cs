using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public MenuManager pausePanel;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.gameObject.SetActive(true);
        }
    }
}
