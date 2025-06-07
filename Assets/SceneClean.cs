using UnityEngine;


public class SceneCleanup : MonoBehaviour
{
    void Start()
    {
        GameObject existingSun = GameObject.FindWithTag("Sun");
        if (existingSun != null)
        {
            Destroy(existingSun);
        }
    }
}
