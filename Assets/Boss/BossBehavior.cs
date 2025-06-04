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
    public float speed;

    public Sprite phase1Sprite; 
    public Sprite phase2Sprite; 
    private SpriteRenderer spriteRenderer;
    public GameObject enemy;
    public int startingPoint;
    public Transform[] points;

    private float attackTimer;
    private bool changedPhase = false;
    private int i;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = phase1Sprite;
        maxHealth = health;
        transform.position = points[startingPoint].position;
    }

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= timeBetweenAttacks)
        {
            Attack();
            attackTimer = 0f;
        }
        if (Vector2.Distance(transform.position, points[i].position) < 3.5f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        if (changedPhase == true) { timeBetweenAttacks = 1f; speed = 3; }
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
        int alea = Random.Range(0, 2);
        if (changedPhase == true)
        {
            int rand = Random.Range(0, 5);
            foreach (Transform point in fallPoints)
            {
                if (rand != 4)
                    Instantiate(fallingObjectPrefab, point.position, Quaternion.identity);
                else
                {
                    GameObject spawnedEnemy = Instantiate(enemy, point.position, Quaternion.identity);
                    Enemybehavior enemybehavior = spawnedEnemy.GetComponent<Enemybehavior>();
                    if (enemybehavior != null)
                    {
                        enemybehavior.DisableSpawnCoin();
                    }
                    else
                    {
                        Debug.LogError($"Prefab {enemy.name} is missing EnemyBehavior component!");
                    }
                }
            }
        }
        else 
        {
            foreach (Transform point in fallPoints)
                if (alea==0)
            Instantiate(fallingObjectPrefab, point.position, Quaternion.identity);
            else Instantiate(fallingObjectPrefab, point.position + new Vector3(-5, 0,0), Quaternion.identity);

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
