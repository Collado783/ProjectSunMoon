using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    BoxCollider2D myBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBox = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            //move right.
            myRigidBody.linearVelocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            //Move left.
            myRigidBody.linearVelocity = new Vector2(-moveSpeed, 0f);
        }
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turn around
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.linearVelocity.x)),
        transform.localScale.y);
    }
}
