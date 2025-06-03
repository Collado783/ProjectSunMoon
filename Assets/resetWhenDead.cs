using UnityEngine;
using UnityEngine.SceneManagement;

public class resetWhenDead : MonoBehaviour
{
    float resetTime=2;
    float resetTimer;
    public GameObject player;
    private void Update()
    {
        if (player == null)
        {
            resetTimer += Time.deltaTime;
            if (resetTimer >= resetTime) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

        }
    }
}
