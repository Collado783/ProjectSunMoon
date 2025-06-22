using UnityEngine;


public class ProjectileArea : ProjectileBehavior
{
    public float explosionRadius = 2f;
    public int attack;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
       

        foreach (var hit in hits)
        {
            var enemy = hit.GetComponent<Enemybehavior>();
            var boss = hit.GetComponent<BossBehavior>();

            if (enemy)
                enemy.TakeHit(attack);

            if (boss)
                boss.TakeDamage(attack);
        }

        base.OnCollisionEnter2D(collision); 
    }

    private void OnDrawGizmosSelected()
    {
        // Esto solo dibuja el radio en el editor, no hace nada más 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
