using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 5f;
    private float lifetime;
    private float resetTime = 5;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
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
    }
}
