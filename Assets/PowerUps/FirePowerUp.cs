using Mono.Cecil;
using UnityEngine;

public class PowerUpFire : PowerUpBehavior
{
    

    protected override void ApplyEffect(Char2DMover player)
    {
        Char2DShooter shooter = player.GetComponent<Char2DShooter>();
        if (shooter != null)
        {
            shooter.firePowerUp = true;
        }

       
    }
}
