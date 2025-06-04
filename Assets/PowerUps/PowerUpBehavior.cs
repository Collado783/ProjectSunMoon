using UnityEngine;

public class PowerUpBehavior: MonoBehaviour
{
    public float resource = 100;
    public PowerUpSpawner spawner;
    protected void OnTriggerEnter2D(Collider2D collision)
    {

        var player = collision.GetComponent<Char2DMover>();

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

