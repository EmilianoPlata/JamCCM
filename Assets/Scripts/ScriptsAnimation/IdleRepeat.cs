using UnityEngine;

public class IdleRepeat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float timer = 0f;
    [SerializeField] private float repeatDelay = 10f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= repeatDelay)
        {
            animator.Play("Idle", 0, 0f); // Reproduce desde el inicio
            timer = 0f;
        }
    }
}

