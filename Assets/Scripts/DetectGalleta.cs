using UnityEngine;

public class DetectGalleta : MonoBehaviour
{
    private string mensaje = "Comido";

    void Start()
    {
        // Esto ya no es necesario, trabajaremos directamente con el objeto de colisión
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Galleta"))
        {
            Debug.Log(mensaje);
            Destroy(collision.gameObject);  // Destruye el objeto que colisionó
        }
    }
}