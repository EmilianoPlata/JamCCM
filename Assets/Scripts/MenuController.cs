using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private Button btnJugar;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        btnJugar = root.Q<Button>("PlayButton");
        btnJugar.clicked += Juego;

    }
    
    private void Juego() {
        SceneManager.LoadScene("Nivel1");
    }
}
