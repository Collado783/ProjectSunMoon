using UnityEngine;




public class Char2DMover : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;

    private Rigidbody2D _rigidbody;
    private float _distance;
    public float distanceDelta = 0.1f;
    public Animator animator;
    float timer=0;
    public float desiredTime=1;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float width = GetComponent<Collider2D>().bounds.extents.x;
        _distance = width + distanceDelta;
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        if (animator.GetBool("IsJumping") == true)
        {
            timer += Time.deltaTime; if (timer >= desiredTime) { animator.SetBool("IsJumping", false); timer = 0; }
        }
    }

    private void HandleMovement()
    {
        IsGrounded();
        float movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));
        int layerMask = LayerMask.GetMask("Map");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(movement), _distance, layerMask);

        if (hit.collider == null)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        }

        if (!Mathf.Approximately(movement, 0))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.linearVelocity.y) < 0.001f && _rigidbody.gravityScale == 3.5)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.linearVelocity.y) < 0.001f && _rigidbody.gravityScale == -3.5)
        {
            _rigidbody.AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
                

            
        
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    private bool IsGrounded()
    {
        float direction = Mathf.Sign(_rigidbody.gravityScale);
        float distance = 0.1f;
        int layerMask = LayerMask.GetMask("Map");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * direction, distance, layerMask);
        return hit.collider != null;
    }
}
