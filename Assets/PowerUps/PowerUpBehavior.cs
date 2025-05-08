using UnityEngine;

public class PowerUpBehavior: MonoBehaviour
{
    public float resource = 100;
    protected void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<Char2DMover>();

        if (player)
        {

            player.Recharge(resource);
            Destroy(gameObject);
            ammoManager.instance.AddPoint();
        }


        
     
         
        
     
    }
    
}

