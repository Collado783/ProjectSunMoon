using UnityEngine;

public class ProjectileNormal : ProjectileBehavior
{
    public int attack;
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemybehavior>();
        var boss = collision.collider.GetComponent<BossBehavior>();

        if (enemy)
            enemy.TakeHit(attack);

        if (boss)
            boss.TakeDamage(attack);

        base.OnCollisionEnter2D(collision); 
    }
}
