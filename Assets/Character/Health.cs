using UnityEngine;


public class Health: MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    [SerializeField] private AudioClip explosionClip;
    public GameObject Explosion;
    public Transform pos;
    [SerializeField] private AudioClip hitSound;



    private void Awake()
    {
        currentHealth = startingHealth;
       
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        AudioSource.PlayClipAtPoint(hitSound, pos.position, 1000000f);
        if (currentHealth > 0)
        {
           
        }
        else
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionClip, pos.position, 1f);
            GameObject ExplosionObject = Instantiate(Explosion, pos.position, transform.rotation);

            AudioSource.PlayClipAtPoint(explosionClip, pos.position, 1f);

            Destroy(ExplosionObject, 1.2f);
            
            

        }
    }
  
    

}
