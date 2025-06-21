using UnityEngine;

public class Launcher: MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireballPrefab;
    private float cooldownTimer;

    private void Attack()
    {
        cooldownTimer = 0;

        GameObject newFireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        newFireball.GetComponent<FireBall>().ActivateProjectile();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }
}


