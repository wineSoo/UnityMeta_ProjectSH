using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public float speed;
    public GameObject characterVisual; // → PF Player 연결

    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = characterVisual.GetComponent<Animator>();
        rb = characterVisual.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        rb.velocity = speed * dir;
    }
}