using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UINiveles : MonoBehaviour {
    [SerializeField] private UIDocument uiDocumentMenu; // Asigna desde el inspector
    private Button btnVolver;
    private VisualElement contenedorPopUp;
    private Button buttonNivel1;
    private Button buttonNivel2;
    private Button buttonNivel3;
    private Button buttonNivel4;
    private Button buttonNivel5;
    private Button buttonNivel6;
    private Button buttonNivel7;
    private Button buttonNivel8;
    private Button buttonNivel9;
    private Button buttonNivel10;
    private Button buttonNivel11;


    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        contenedorPopUp = root.Q<VisualElement>("ContenedorPrincipal");

        btnVolver = root.Q<Button>("CloseButton");
        btnVolver.clicked += Volver;

        buttonNivel1 = root.Q<Button>("1");
        buttonNivel2 = root.Q<Button>("2");
        buttonNivel3 = root.Q<Button>("3");
        buttonNivel4 = root.Q<Button>("4");
        buttonNivel5 = root.Q<Button>("5");
        buttonNivel6 = root.Q<Button>("6");
        buttonNivel7 = root.Q<Button>("7");
        buttonNivel8 = root.Q<Button>("8");
        buttonNivel9 = root.Q<Button>("9");
        buttonNivel10 = root.Q<Button>("10");
        buttonNivel11 = root.Q<Button>("11");

        buttonNivel1.clicked += () => CargarNivel(1);
        buttonNivel2.clicked += () => CargarNivel(2);
        buttonNivel3.clicked += () => CargarNivel(3);
        buttonNivel4.clicked += () => CargarNivel(4);
        buttonNivel5.clicked += () => CargarNivel(5);
        buttonNivel6.clicked += () => CargarNivel(6);
        buttonNivel7.clicked += () => CargarNivel(7);
        buttonNivel8.clicked += () => CargarNivel(8);
        buttonNivel9.clicked += () => CargarNivel(9);
        buttonNivel10.clicked += () => CargarNivel(10);
        buttonNivel11.clicked += () => CargarNivel(11);

        contenedorPopUp.visible = false;
    }

    private void CargarNivel(int indexScene) {
        if (indexScene == 1) { 
            GlobalVariables.indexScene = 2;
            SceneManager.LoadScene("Nivel1");
        } else if (indexScene == 2) {
            GlobalVariables.indexScene = 3;
            SceneManager.LoadScene("Nivel2");
        } else if (indexScene == 3) {
            GlobalVariables.indexScene = 4;
            SceneManager.LoadScene("Nivel3");
        } else if (indexScene == 4) {
            GlobalVariables.indexScene = 5;
            SceneManager.LoadScene("Nivel4");
        } else if (indexScene == 5) {
            GlobalVariables.indexScene = 6;
            SceneManager.LoadScene("Nivel5");
        } else if (indexScene == 6) {
            GlobalVariables.indexScene = 7;
            SceneManager.LoadScene("Nivel6");
        } else if (indexScene == 7) {
            GlobalVariables.indexScene = 8;
            SceneManager.LoadScene("Nivel7");
        } else if (indexScene == 8) {
            GlobalVariables.indexScene = 9;
            SceneManager.LoadScene("Nivel8");
        } else if (indexScene == 9) {
            GlobalVariables.indexScene = 10;
            SceneManager.LoadScene("Nivel9");
        } else if (indexScene == 10) {
            GlobalVariables.indexScene = 11;
            SceneManager.LoadScene("Nivel10");
        } else if (indexScene == 11) {
            GlobalVariables.indexScene = 12;
            SceneManager.LoadScene("Nivel11");
        }
    }

    private void Volver()
    {
        if (uiDocumentMenu == null)
        {
            Debug.LogError("Referencia a UIDocument del menú no asignada");
            return;
        }
        VisualElement rootMenu = uiDocumentMenu.rootVisualElement;
        rootMenu.visible = true;

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;
        contenedorPopUp.visible = false;
    }
}





