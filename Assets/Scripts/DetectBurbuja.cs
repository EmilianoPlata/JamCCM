using UnityEngine;

public class DetectBurbuja : MonoBehaviour
{
    private GameObject burbuja;
    private Rigidbody2D rbGalleta;
    private SpriteRenderer burbujaSp;
    private CircleCollider2D circleCollider2D;

    private void Start()
    {

        GameObject parentBurbuja = GameObject.FindGameObjectWithTag("Galleta");
        rbGalleta = parentBurbuja.GetComponent<Rigidbody2D>();

        burbuja = parentBurbuja.transform.GetChild(0).gameObject;
        burbujaSp = burbuja.GetComponent<SpriteRenderer>();
        circleCollider2D = burbuja.GetComponent<CircleCollider2D>(); 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Burbuja"))
        {
            Destroy(collision.gameObject);
            // Destruye la burbuja al colisionar
            rbGalleta.gravityScale = rbGalleta.gravityScale * -40;
            circleCollider2D.enabled = true; 
            burbujaSp.enabled = true;
        }
    }
}