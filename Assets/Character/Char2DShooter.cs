using UnityEngine;

public class Char2DShooter : MonoBehaviour
{
    
    public float ammo = 100;
    public GameObject projectileNormal;
    public GameObject projectileArea;
    public Transform launchOffset;
    public bool firePowerUp = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (ammo <= 0) return;

        if (firePowerUp)
        {
            ammoManager.instance.Fire(20);
            Instantiate(projectileArea, launchOffset.position, transform.rotation);
            ammo -= 20;
        }
        else
        {
            ammoManager.instance.Fire(10);
            Instantiate(projectileNormal, launchOffset.position, transform.rotation);
            ammo -= 10;
        }
    }

    public void Recharge(float value)
    {
        ammo = value;
    }
}
