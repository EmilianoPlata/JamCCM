using UnityEngine;
public class DynamicRope : MonoBehaviour
{

    private string mensaje = "dentro del rango de cuerda";
    private bool yaEntro = false; 
    public Rigidbody2D hook;  // Corrected capitalization
    public GameObject linkPrefab;
    public int links = 7;
    public Weight weight; 

    void Start() {
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Galleta") && yaEntro == false)
        {
            Debug.Log(mensaje);
            GenerateRope();
            yaEntro = true; 
        }
    }


    void GenerateRope() 
    {
        Rigidbody2D previousRB = hook;  // Corrected here as well
        for (int i = 0; i < links; i++) {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if(i < links - 1) {
                previousRB = link.GetComponent<Rigidbody2D>();  // And here
            } else {
                weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }
    }
}
