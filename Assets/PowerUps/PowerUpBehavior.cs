using UnityEngine;

public abstract class PowerUpBehavior : MonoBehaviour
{
    public PowerUpSpawner spawner;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Char2DMover>();
        if (player)
        {
            ApplyEffect(player);

            if (spawner != null)
                spawner.NotifyPowerUpCollected();

            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(Char2DMover player);
}

