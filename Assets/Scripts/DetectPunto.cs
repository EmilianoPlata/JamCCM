using UnityEngine;
public class DetectPunto : MonoBehaviour  {
    private int puntos = 0; // Inicializado correctamente
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Punto")) 
        {   
            puntos++; // Incrementa en 1 cada colisión
            Debug.Log("Puntos: " + puntos);
            Destroy(collision.gameObject);
        }
    }
}