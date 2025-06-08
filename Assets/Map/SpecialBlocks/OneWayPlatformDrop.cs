using UnityEngine;

public class OneWayPlatformDrop : MonoBehaviour
{
    private PlatformEffector2D effector;
    private bool playerOnPlatform = false;
    private Collider2D playerCollider;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (playerOnPlatform && Input.GetKeyDown(KeyCode.S))
        {
            
            effector.rotationalOffset = 180f;
            Invoke("ResetEffector", 0.5f);
        }
    }

    void ResetEffector()
    {
        effector.rotationalOffset = 0f;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = true;
            playerCollider = collision.collider;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = false;
            playerCollider = null;
        }
    }
}
