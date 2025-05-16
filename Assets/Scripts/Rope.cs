using UnityEngine;
public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;  // Corrected capitalization
    public GameObject linkPrefab;
    public int links = 7;
    public Weight weight; 

    void Start() {
        GenerateRope();
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
