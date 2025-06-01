using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float Speed = 7f;
    private float lifetime;
    private float resetTime=5;
    private void Update()
    {
        transform.position -= transform.right * Time.deltaTime * Speed;
        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemybehavior > ();
        var boss = collision.collider.GetComponent<BossBehavior>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }
        if (boss)
        {
            boss.TakeDamage(1);
        }
        Destroy(gameObject);
    }
    

}
