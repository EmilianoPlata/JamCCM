using UnityEngine;
using UnityEngine.SceneManagement;
public class BubblePopper : MonoBehaviour {
    private string nameScene;
    private GameObject burbuja;
    private Rigidbody2D rbGalleta;
    private SpriteRenderer burbujaSp;

    private void Start() {

        GameObject parentBurbuja = GameObject.FindGameObjectWithTag("Galleta");
        rbGalleta = parentBurbuja.GetComponent<Rigidbody2D>();

        burbuja = parentBurbuja.transform.GetChild(0).gameObject;
        burbujaSp = burbuja.GetComponent<SpriteRenderer>();
        nameScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("BurbujaPonchar"))
                {
                    // Destruye la burbuja al colisionar
                    rbGalleta.gravityScale = 1;
                    rbGalleta.linearDamping = 0.1f;
                    burbujaSp.enabled = false;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}