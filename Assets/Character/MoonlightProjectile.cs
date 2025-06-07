using UnityEngine;

public class ProjectileNormal : ProjectileBehavior
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemybehavior>();
        var boss = collision.collider.GetComponent<BossBehavior>();

        if (enemy)
            enemy.TakeHit(1);

        if (boss)
            boss.TakeDamage(1);

        base.OnCollisionEnter2D(collision); 
    }
}
