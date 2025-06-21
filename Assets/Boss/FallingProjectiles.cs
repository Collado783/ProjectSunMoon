using UnityEngine;

public class FallingProjectiles : MonoBehaviour
{
    float fallSpeed = 3f;
    private float lifetime;
    private float resetTime = 5;
    public int attack;

    
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
            collision.gameObject.GetComponent<Health>().TakeDamage(attack);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
