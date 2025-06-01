using UnityEngine;

public class FallingProjectiles : MonoBehaviour
{
    public float fallSpeed = 3f;
    private float lifetime;
    private float resetTime = 5;

    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
