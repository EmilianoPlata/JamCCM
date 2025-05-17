using System.Collections;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject cortador;
    [SerializeField] private SpriteRenderer chocoreta;
    private bool fueRecolectada = false;

    public void MarcarComoRecolectada()
    {
        fueRecolectada = true;
    }

    void OnBecameInvisible()
    {
        if (!fueRecolectada)
        {
            chocoreta.enabled = false;
            anim.SetBool("Perder", true);
            StartCoroutine(EsperarAnimacion());

        }
    }

    private IEnumerator EsperarAnimacion()
    {
        yield return new WaitForSeconds(4f);
        menuGameOver.SetActive(true);
        cortador.SetActive(false);
    }

}

