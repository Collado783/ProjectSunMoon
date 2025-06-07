using UnityEngine;

public class PowerUpFire : PowerUpBehavior
{
    

    protected override void ApplyEffect(Char2DMover player)
    {
        player.firePowerUp = true;
    }
}
