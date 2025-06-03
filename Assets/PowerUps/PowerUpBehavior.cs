using UnityEngine;

public class PowerUpBehavior: MonoBehaviour
{
    public float resource = 100;
    public PowerUpSpawner spawner;
    protected void OnCollisionEnter2D(Collision2D collision)
    {


        var player = collision.collider.GetComponent<Char2DMover>();

        if (player)
        {
            if (spawner != null)
            {
                spawner.NotifyPowerUpCollected();
            }
            player.Recharge(resource);
            Destroy(gameObject);
            ammoManager.instance.AddPoint();
        }


        
     
         
        
     
    }
    
}

