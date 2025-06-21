using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    float speed = 5f;
    private float lifetime;
    private float resetTime = 5;
    public int attack;
    private void Start()
    {
        
        Physics.IgnoreLayerCollision(0,8,true);
    }
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
            collision.gameObject.GetComponent<Health>().TakeDamage(attack);
            Destroy(gameObject);
        }
    }
}
