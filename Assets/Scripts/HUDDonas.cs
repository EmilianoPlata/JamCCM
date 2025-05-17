using UnityEngine;
using UnityEngine.UI;

public class HUDDonas : MonoBehaviour
{
    public Image[] donasUI; // Asigna 3 imágenes en el inspector
    public Sprite donaLlena;
    public Sprite donaVacia;

    void Update()
    {
        for (int i = 0; i < donasUI.Length; i++)
        {
            if (i < DetectPunto.puntos) // puntos = donas recolectadas
                donasUI[i].sprite = donaLlena;
            else
                donasUI[i].sprite = donaVacia;
        }
    }
}

