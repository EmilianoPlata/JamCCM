using UnityEngine;
public class DetectPincho : MonoBehaviour  {
    private string mensaje = "perdiste";
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Galleta")) 
        {   
            Debug.Log(mensaje);
            Destroy(collision.gameObject);  // Destruye el objeto que colisionó
        }
    }
}