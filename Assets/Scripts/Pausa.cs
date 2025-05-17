using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject panelPause;

    private bool inPause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            inPause = !inPause;

        if (inPause)
        {
            panelPause.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            panelPause.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
