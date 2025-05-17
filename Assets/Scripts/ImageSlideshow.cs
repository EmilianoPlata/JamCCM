using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSlideshow : MonoBehaviour
{
    public Image[] images;        // Array para almacenar las imágenes
    public float transitionTime = 1f; // Duración de la transición
    public float displayTime = 3f;    // Tiempo que cada imagen permanece visible

    private int currentIndex = 0;

    void Start()
    {
        // Inicializa todas las imágenes con alfa 0, excepto la primera
        foreach (Image img in images) img.color = new Color(1, 1, 1, 0);
        images[currentIndex].color = new Color(1, 1, 1, 1);
        StartCoroutine(SlideShowCoroutine());
    }

    IEnumerator SlideShowCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(displayTime);
            StartCoroutine(FadeOut(images[currentIndex]));
            currentIndex = (currentIndex + 1) % images.Length;
            StartCoroutine(FadeIn(images[currentIndex]));
        }
    }

    IEnumerator FadeIn(Image img)
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime / transitionTime;
            img.color = new Color(1, 1, 1, Mathf.Clamp01(alpha));
            yield return null;
        }
    }

    IEnumerator FadeOut(Image img)
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / transitionTime;
            img.color = new Color(1, 1, 1, Mathf.Clamp01(alpha));
            yield return null;
        }
    }
}
