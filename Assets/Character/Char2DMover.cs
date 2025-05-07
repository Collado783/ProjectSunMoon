using UnityEngine;

public class Char2DMover : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;
    public float Ammo = 100;
    public CoinBehavior cb;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        
        if(!Mathf.Approximately(movement, 0))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.linearVelocity.y)<0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (Ammo > 0)
            {
                ammoManager.instance.Fire();
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            }
        }
    }
    public void Recharge(float resource)
    {
        Ammo = resource;
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            cb.coinCount++;
        }
    }

}
