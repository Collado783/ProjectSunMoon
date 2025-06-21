using UnityEngine;

public abstract class PowerUpBehavior : MonoBehaviour
{
    public PowerUpSpawner spawner;
    [SerializeField] private AudioClip powerUpSound;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Char2DMover>();
        if (player)
        {
            ApplyEffect(player);
                AudioSource.PlayClipAtPoint(powerUpSound, transform.position, 1000000f); ;

            if (spawner != null)
                spawner.NotifyPowerUpCollected();

            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(Char2DMover player);
}

