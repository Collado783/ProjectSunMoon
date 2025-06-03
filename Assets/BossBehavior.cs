using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject fallingObjectPrefab;
    public Transform shootPoint;
    public Transform[] fallPoints;
    public float timeBetweenAttacks = 2f;
    public int health = 10;
    private int maxHealth;

    public Sprite phase1Sprite; 
    public Sprite phase2Sprite; 
    private SpriteRenderer spriteRenderer;

    private float attackTimer;
    private bool changedPhase = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = phase1Sprite;
        maxHealth = health;
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= timeBetweenAttacks)
        {
            Attack();
            attackTimer = 0f;
        }
    }

    void Attack()
    {
        int rand = Random.Range(0, 2); 

        if (rand == 0)
            ShootProjectile();
        else
            DropFallingObjects();
    }

    void ShootProjectile()
    {
        Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
    }

    void DropFallingObjects()
    {
        foreach (Transform point in fallPoints)
        {
            Instantiate(fallingObjectPrefab, point.position, Quaternion.identity);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        
        if (!changedPhase && health <= maxHealth / 2)
        {
            spriteRenderer.sprite = phase2Sprite;
            changedPhase = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    
   
}
