using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private Button btnJugar;
    private Button btnCreditos;
    private UIDocument uIDocumentCreditos;
    private VisualElement rootCreditos;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        btnJugar = root.Q<Button>("PlayButton");
        btnCreditos = root.Q<Button>("CreditButton");

        GameObject uiCreditosGO = GameObject.Find("UICreditos");
        uIDocumentCreditos = uiCreditosGO.GetComponent<UIDocument>();
        rootCreditos = uIDocumentCreditos.rootVisualElement;

        btnJugar.clicked += Juego;
        btnCreditos.clicked += Creditos;

    }

    private void Juego()
    {
        SceneManager.LoadScene("Nivel1");
    }

    private void Creditos()
    {
    VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    root.visible = false;
    rootCreditos.visible = true;

    // Mostrar el contenedor principal de créditos
    var contenedorPopUp = rootCreditos.Q<VisualElement>("ContenedorPrincipal");
    if (contenedorPopUp != null)
        contenedorPopUp.visible = true;
    }
}
