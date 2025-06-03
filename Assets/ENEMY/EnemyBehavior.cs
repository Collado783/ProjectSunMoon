using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Enemybehavior : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 3;
    public GameObject Explosion;
    public GameObject coin;
    public Transform pos;
    [SerializeField]private AudioClip explosionClip;
    float hitCooldown = 1;
    float hitTimer;
  

    private void Start()
    {
        Hitpoints = MaxHitpoints;
       
    }
    private void Update()
    {
        hitTimer += Time.deltaTime;
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            
            Destroy(gameObject);
            

           GameObject ExplosionObject = Instantiate(Explosion, pos.position, transform.rotation);
            GameObject dropCoin = Instantiate(coin, pos.position, transform.rotation); 
            
            AudioSource.PlayClipAtPoint(explosionClip, pos.position, 1f);

            Destroy(ExplosionObject, 1.2f);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<Health>();


        if (player&&hitTimer>=hitCooldown)
        {
            player.TakeDamage(1);
            hitTimer = 0;
            
        }

    }
}
