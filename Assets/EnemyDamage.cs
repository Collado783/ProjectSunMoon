using UnityEngine;

public class TrapDamage: MonoBehaviour
{
  
        [SerializeField] protected float damage;

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }






    
}
