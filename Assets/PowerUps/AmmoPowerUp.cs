using UnityEngine;

public class PowerUpRecharge : PowerUpBehavior
{
    public float resource = 100f;

    protected override void ApplyEffect(Char2DMover player)
    {
        player.Recharge(resource);
        ammoManager.instance.AddPoint();
    }
}
