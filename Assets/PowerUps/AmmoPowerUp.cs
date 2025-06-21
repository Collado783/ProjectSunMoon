using UnityEngine;

public class PowerUpRecharge : PowerUpBehavior
{
    public float resource = 100f;

    protected override void ApplyEffect(Char2DMover player)
    {
        Char2DShooter shooter = player.GetComponent<Char2DShooter>();
        if (shooter != null)
        {
            shooter.Recharge(resource);
        }

        ammoManager.instance.AddPoint();
    }
}
