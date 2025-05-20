using UnityEngine;

public class Char2DMover : MonoBehaviour
{
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public GameObject ProjectilePrefab;
    public Transform LaunchOffset;
    public float Ammo = 100;

    public float distanceDelta = 0.1f;
    private float _distance;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Collider2D collider = gameObject.GetComponent<Collider2D>();
        float width = collider.bounds.extents.x;
        _distance = width + distanceDelta;
    }
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");

        Debug.DrawRay(transform.position-Vector3.down*-0.7f, Vector2.right * Mathf.Sign(movement) * _distance, Color.red);
        Debug.DrawRay((transform.position - Vector3.down * -0.7f) - (Vector3.right * Mathf.Sign(movement) * _distance), Vector2.right * Mathf.Sign(movement) * _distance, Color.blue);
        Debug.DrawRay(transform.position, Vector2.right * Mathf.Sign(movement) * _distance, Color.red);
        Debug.DrawRay((transform.position) - (Vector3.right * Mathf.Sign(movement) * _distance), Vector2.right * Mathf.Sign(movement) * _distance, Color.blue);

        int layerMask = 1 << LayerMask.NameToLayer("Map") | 0 << LayerMask.NameToLayer("Default");
        RaycastHit2D raycastHit2Drd = Physics2D.Raycast(transform.position - Vector3.down * -0.7f, Vector2.right * Mathf.Sign(movement), _distance, layerMask);
        RaycastHit2D raycastHit2Dld = Physics2D.Raycast((transform.position - Vector3.down * -0.7f), Vector2.right * Mathf.Sign(movement), _distance, layerMask);
        RaycastHit2D raycastHit2Dru = Physics2D.Raycast(transform.position - Vector3.down * -0.7f, Vector2.right * Mathf.Sign(movement), _distance, layerMask);
        RaycastHit2D raycastHit2Dlu = Physics2D.Raycast((transform.position - Vector3.down * -0.7f), Vector2.right * Mathf.Sign(movement), _distance, layerMask);


        if (/*movement > 0 && */raycastHit2Drd.collider == null || raycastHit2Dru.collider == null)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
      
        }
        //else if (movement < 0 && raycastHit2Dl.collider == null)
        //{
        //    transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        //    Debug.Log("Moving right");
        //}
       


        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.linearVelocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (!Mathf.Approximately(movement, 0))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.linearVelocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (Ammo > 0)
            {
                ammoManager.instance.Fire();
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                Ammo -= 10;

            }
        }
    }
    public void Recharge(float resource)
    {
        Ammo = resource;
    }


}
