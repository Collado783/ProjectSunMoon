using UnityEngine;
using UnityEngine.SceneManagement;

public class SunBehavior : MonoBehaviour
{
    private float speed;
    public AudioClip newTrack;
    private AudioManager audioManager;
    void Awake()
    {
        GameObject existingSun = GameObject.FindWithTag("Sun");

        if (existingSun != null && existingSun != gameObject)
        {
            Destroy(gameObject);
            return;
        }
    }
    public void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        if (newTrack != null)
        {
            audioManager.ChangeMusic(newTrack);
        }
    }
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
        var player = collision.collider.GetComponent<Char2DMover>();

        if (player)
        {
            GameManager.Instance.fiveLevelsCompleted = true; 
            SceneManager.LoadSceneAsync(SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/MainMenu.unity"));
        }
    }
}
