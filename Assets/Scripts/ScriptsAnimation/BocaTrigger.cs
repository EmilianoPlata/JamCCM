using UnityEngine;

public class BocaTrigger : MonoBehaviour
{

    [SerializeField] private Animator animator;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Galleta"))
        {
            animator.SetBool("Cerca", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Cerca", false);
    }
}
