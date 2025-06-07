using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float Speed = 10f;
    public float resetTime = 5f;
    protected float lifetime;

    protected virtual void Update()
    {
        transform.position -= transform.right * Speed * Time.deltaTime;
        lifetime += Time.deltaTime;

        if (lifetime >= resetTime)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); 
    }
}
