using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectBurbuja : MonoBehaviour
{
    private string nameScene;
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
        nameScene = SceneManager.GetActiveScene().name;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Burbuja"))
        {
            Destroy(collision.gameObject);
            // Destruye la burbuja al colisionar

            if (nameScene == "Nivel6")
            {
                rbGalleta.gravityScale = rbGalleta.gravityScale * -40;

                rbGalleta.linearDamping = 100;
                circleCollider2D.enabled = true;
                burbujaSp.enabled = true;
            }
            else if (nameScene == "Nivel5" || nameScene == "Nivel8" || nameScene == "Nivel9")
            {
                rbGalleta.gravityScale = rbGalleta.gravityScale * -60;
                circleCollider2D.enabled = true;
                burbujaSp.enabled = true;
            }
        }
    }
}