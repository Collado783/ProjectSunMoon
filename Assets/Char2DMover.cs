using UnityEngine;

public class Char2DMover : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.linearVelocity.y)<0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }

}
