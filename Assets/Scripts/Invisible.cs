using UnityEngine;

public class Invisible : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void OnBecameInvisible()
    {
        anim.SetBool("Perder", true);
        Destroy(gameObject);
        Debug.Log("Triste");
    }
}
