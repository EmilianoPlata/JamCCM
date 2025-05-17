using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class ScoreResume : MonoBehaviour
{
    private UIDocument uiDocumentResume;
    private Button btnMenu;
    private Button btnRejugar;
    private Button btnSiguiente;

    private void contarDonas() {
    // Obtén el root visual
    uiDocumentResume = GetComponent<UIDocument>();
    VisualElement root = uiDocumentResume.rootVisualElement;

    // Obtén los iconos de donas
    var dona1 = root.Q<VisualElement>("iconDonas1");
    var dona2 = root.Q<VisualElement>("iconDonas2");
    var dona3 = root.Q<VisualElement>("iconDonas3");

    // Oculta todas las donas al inicio
    dona1.style.display = DisplayStyle.None;
    dona2.style.display = DisplayStyle.None;
    dona3.style.display = DisplayStyle.None;

    // Muestra la cantidad de donas según los puntos
    int puntos = DetectPunto.puntos;
    if (puntos >= 1) dona1.style.display = DisplayStyle.Flex;
    if (puntos >= 2) dona2.style.display = DisplayStyle.Flex;
    if (puntos >= 3) dona3.style.display = DisplayStyle.Flex;
    }

    private void OnEnable()
    {

        contarDonas();

        uiDocumentResume = GetComponent<UIDocument>();
        VisualElement root = uiDocumentResume.rootVisualElement;
        btnMenu = root.Q<Button>("MenuButton");
        btnRejugar = root.Q<Button>("ReplayButton");
        btnSiguiente = root.Q<Button>("NextButton");

        btnMenu.clicked += VolverMenu;
        btnRejugar.clicked += VolverNivelAnterior;
        btnSiguiente.clicked += VolverNivelSiguiente;
    }

    private void VolverMenu()
    {
        SceneManager.LoadScene("PantallaInicio");
    }

    private void VolverNivelAnterior() {
        GlobalVariables.indexScene -= 1;
        SceneManager.LoadScene(GlobalVariables.indexScene);
    }
    
    private void VolverNivelSiguiente() {
        DetectPunto.puntos = 0; // Reinicia los puntos
        GlobalVariables.indexScene += 1;
        SceneManager.LoadScene(GlobalVariables.indexScene);
    }
}
