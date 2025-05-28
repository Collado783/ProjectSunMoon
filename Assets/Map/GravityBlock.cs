using UnityEngine;

public class GravityBlock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
               
                rb.gravityScale *= -1;

               
                Vector3 scale = other.transform.localScale;
                scale.y *= -1;
                other.transform.localScale = scale;
            }
        }
    }
}
