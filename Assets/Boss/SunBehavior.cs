using UnityEngine;
using UnityEngine.SceneManagement;

public class SunBehavior : MonoBehaviour
{
    private float speed;


    public void Initialize(float descendSpeed)
    {
        speed = descendSpeed;

    }

    void Update()
    {


        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(transform.position.x, transform.position.z),
            speed * Time.deltaTime
        );

    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadSceneAsync(SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/MainMenu.unity"));
    }
}
