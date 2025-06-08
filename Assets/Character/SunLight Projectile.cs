using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ProjectileArea : ProjectileBehavior
{
    public float explosionRadius = 2f;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
       

        foreach (var hit in hits)
        {
            var enemy = hit.GetComponent<Enemybehavior>();
            var boss = hit.GetComponent<BossBehavior>();

            if (enemy)
                enemy.TakeHit(2);

            if (boss)
                boss.TakeDamage(2);
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
