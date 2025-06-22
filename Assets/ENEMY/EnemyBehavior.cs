using UnityEngine;


public class Enemybehavior : MonoBehaviour
{
    public float hitpoints;
    public float maxHitpoints;
    public GameObject explosion;
    public GameObject coin;
    public Transform pos;
    [SerializeField] private AudioClip explosionClip;
    float hitCooldown = 1;
    float hitTimer;
    bool spawnCoin=true;
    public int attack;
    

    private void Start()
    {
        hitpoints = maxHitpoints;
        hitTimer = hitCooldown;

    }
    private void Update()
    {
        hitTimer += Time.deltaTime;
        
    }
    public void TakeHit(float damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0)
        {

            Destroy(gameObject);


            GameObject ExplosionObject = Instantiate(explosion, pos.position, transform.rotation);
            if (spawnCoin) { GameObject dropCoin = Instantiate(coin, pos.position, transform.rotation); }

            AudioSource.PlayClipAtPoint(explosionClip, pos.position,  1f);

            Destroy(ExplosionObject, 1.2f);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<Health>();


        if (player && hitTimer >= hitCooldown)
        {
            player.TakeDamage(attack);
            hitTimer = 0;
            EnemyPatrol enemyPatrol = GetComponent<EnemyPatrol>();
            if (enemyPatrol != null)
            {
                enemyPatrol.changeDirection();
            }
            else
            { 
                Debug.LogError($"{gameObject.name} is missing enemyPatrol");
            }
        }

    }
    public void DisableSpawnCoin()
    {
        spawnCoin = false;
    }
}
