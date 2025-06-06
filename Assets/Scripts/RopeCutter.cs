using UnityEngine;
public class RopeCutter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Link"))
                {
                    // Destruir una
                    Destroy(hit.collider.gameObject);
                    // Destruir toda la cuerda 
                    Destroy(hit.transform.parent.gameObject, 2f);
                }
            }
        }
    }
}