using UnityEngine;
public class BubblePopper : MonoBehaviour {

    private GameObject burbuja;
    private Rigidbody2D rbGalleta;
    private SpriteRenderer burbujaSp;

    private void Start() {

        GameObject parentBurbuja = GameObject.FindGameObjectWithTag("Galleta");
        rbGalleta = parentBurbuja.GetComponent<Rigidbody2D>();

        burbuja = parentBurbuja.transform.GetChild(0).gameObject;
        burbujaSp = burbuja.GetComponent<SpriteRenderer>();
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
                    burbujaSp.enabled = false;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}