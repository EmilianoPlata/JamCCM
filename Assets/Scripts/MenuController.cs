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
    private VisualElement rootNiveles;

    private UIDocument uIDocumentNiveles;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        btnJugar = root.Q<Button>("PlayButton");
        btnCreditos = root.Q<Button>("CreditButton");

        GameObject uiCreditosGO = GameObject.Find("UICreditos");
        uIDocumentCreditos = uiCreditosGO.GetComponent<UIDocument>();
        rootCreditos = uIDocumentCreditos.rootVisualElement;

        GameObject uiNivelesGO = GameObject.Find("UINiveles");
        uIDocumentNiveles = uiNivelesGO.GetComponent<UIDocument>();
        rootNiveles = uIDocumentNiveles.rootVisualElement;

        btnJugar.clicked += Juego;
        btnCreditos.clicked += Creditos;

    }

    private void Juego()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;
        rootNiveles.visible = true;

        var contenedorPopUp = rootNiveles.Q<VisualElement>("ContenedorPrincipal");
        if (contenedorPopUp != null)
            contenedorPopUp.visible = true;
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
