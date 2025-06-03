using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float rayDist;
    private bool movingRight;
    public Transform groundDetect;
    int layerMask;

    private void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Map") | 0 << LayerMask.NameToLayer("Default");
        if(transform.right.x >= 0) { movingRight= true; }
        else { movingRight= false; }
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);


        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);
        Vector2 wallDirection = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D wallCheck = Physics2D.Raycast(groundDetect.position, wallDirection, rayDist, layerMask);
        Debug.DrawRay(groundDetect.position, Vector2.down * rayDist, Color.green);
        Debug.DrawRay(groundDetect.position, wallDirection * rayDist, Color.red);

        if (groundCheck.collider == false || wallCheck.collider == true)
        {
            changeDirection();
        }
        
    }
    public void changeDirection()
    {
        if (movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}
