using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DetectGalleta : MonoBehaviour
{
    private string mensaje = "Comido";
    private Rigidbody2D rbGalleta;
    private string nameScene;
    [SerializeField] private Animator anim;

    private void Start()
    {
        GameObject parentGalleta = GameObject.FindGameObjectWithTag("Galleta");
        rbGalleta = parentGalleta.GetComponent<Rigidbody2D>();
        nameScene = SceneManager.GetActiveScene().name;

        if (nameScene == "Nivel8")
        {
            float fuerzaSoplado = 240f; // Puedes ajustar este valor
            int direccion = 1; // Usa -1 para izquierda, 1 para derecha
            Vector2 fuerza = new Vector2(fuerzaSoplado * direccion, 0);
            rbGalleta.AddForce(fuerza, ForceMode2D.Impulse);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Galleta"))
        {
            collision.GetComponent<Invisible>()?.MarcarComoRecolectada();
            anim.SetBool("Comer", true);
            Debug.Log(mensaje);
            Destroy(collision.gameObject, 0.1f);
            StartCoroutine(CargarSiguienteEscenaDespuesDeEspera(5f));
        }
    }

    private IEnumerator CargarSiguienteEscenaDespuesDeEspera(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene("ResumeLevel");
    }
}