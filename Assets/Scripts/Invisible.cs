using UnityEngine;

public class Invisible : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool fueRecolectada = false;

    public void MarcarComoRecolectada()
    {
        fueRecolectada = true;
    }

    void OnBecameInvisible()
    {
        if (!fueRecolectada)
        {
            anim.SetBool("Perder", true);
            Debug.Log("Triste: salió de pantalla");
            Destroy(gameObject, 1f); // espera para mostrar animación
        }
    }
}

