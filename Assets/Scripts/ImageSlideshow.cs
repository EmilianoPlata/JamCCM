using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageSlideshow : MonoBehaviour
{
    public Image[] images;
    public float transitionTime = 1f;
    public float displayTime = 3f;

    private int currentIndex = 0;

    void Start()
    {
        foreach (Image img in images) img.color = new Color(1, 1, 1, 0);
        images[currentIndex].color = new Color(1, 1, 1, 1);
        StartCoroutine(SlideShowCoroutine());
    }

    IEnumerator SlideShowCoroutine()
    {
        while (currentIndex < images.Length)
        {
            yield return new WaitForSeconds(displayTime);
            StartCoroutine(FadeOut(images[currentIndex]));
            currentIndex++;
            
            if (currentIndex >= images.Length)
            {
                yield return new WaitForSeconds(transitionTime);
                SceneManager.LoadScene("Nivel1");
                yield break;
            }

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
