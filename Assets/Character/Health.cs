using UnityEngine;

public class Health: MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;
    [SerializeField] private AudioClip explosionClip;
    public GameObject Explosion;
    public Transform pos;
    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            
        }
        else
        {
            Destroy(gameObject);
            Instantiate(Explosion, pos.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosionClip, pos.position, 1f);

        }
    }
}
