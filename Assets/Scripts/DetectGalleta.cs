using UnityEngine;
public class DetectGalleta : MonoBehaviour
{
    private string mensaje = "Comido";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Galleta"))
        {
            Debug.Log(mensaje);
            Destroy(collision.gameObject, 2);
        }
    }
}

