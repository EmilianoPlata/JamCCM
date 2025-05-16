using UnityEngine;

public class BlowerController : MonoBehaviour 
{
    private GameObject blower;
    private Rigidbody2D rbGalleta;
    private PolygonCollider2D colliderBlowerArea;
    private CircleCollider2D colliderGalleta; 
    private GameObject blowerArea;
    private GameObject galleta;
    private float direccion;

    [Header("Configuración de Fuerza")]
    [SerializeField] private float fuerzaSoplado = 10f; // Ajustable en el Inspector

    private void Start()
    {
        galleta = GameObject.FindGameObjectWithTag("Galleta");
        colliderGalleta = galleta.GetComponent<CircleCollider2D>();
        rbGalleta = galleta.GetComponent<Rigidbody2D>();

        blower = GameObject.FindGameObjectWithTag("Blower");
        blowerArea = blower.transform.GetChild(0).gameObject;
        colliderBlowerArea = blowerArea.GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Blower"))
            {
                if (colliderBlowerArea.IsTouching(colliderGalleta))
                {
                    AplicarFuerza();
                }
            }
        }
    }

    private void AplicarFuerza() {
        if (blowerArea.tag == "BlowAreaIzq")
        {
            direccion = Mathf.Sign(-blower.transform.localScale.x);
            
        }
        else if (blowerArea.tag == "BlowAreaDer")
        {
            direccion = Mathf.Sign(blower.transform.localScale.x);
        }       
        
        // Aplica fuerza en el eje X
        Vector2 fuerza = new Vector2(fuerzaSoplado * direccion, 0);
        rbGalleta.AddForce(fuerza, ForceMode2D.Impulse);
        
        Debug.Log($"Aplicando fuerza: {fuerza}");
    }
}