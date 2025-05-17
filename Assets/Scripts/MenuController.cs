using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor.TerrainTools;

public class MenuController : MonoBehaviour
{
    private Button btnJugar;
    private Button btnEndless;
    private Button btnCreditos;
    private Button btnTutorial;
    private UIDocument uIDocumentCreditos;
    private VisualElement rootCreditos;
    private VisualElement rootNiveles;

    private UIDocument uIDocumentNiveles;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        btnJugar = root.Q<Button>("PlayButton");
        btnCreditos = root.Q<Button>("CreditButton");
        btnEndless = root.Q<Button>("EndlessMode");
        btnTutorial = root.Q<Button>("btnTutorial");

        GameObject uiCreditosGO = GameObject.Find("UICreditos");
        uIDocumentCreditos = uiCreditosGO.GetComponent<UIDocument>();
        rootCreditos = uIDocumentCreditos.rootVisualElement;

        GameObject uiNivelesGO = GameObject.Find("UINiveles");
        uIDocumentNiveles = uiNivelesGO.GetComponent<UIDocument>();
        rootNiveles = uIDocumentNiveles.rootVisualElement;

        btnJugar.clicked += Juego;
        btnCreditos.clicked += Creditos;
        btnEndless.clicked += CargarModoEndless;
        btnTutorial.clicked += CargarTutorial;
    }

    private void Juego()
    {
        GlobalVariables.endlessMode = false;
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.visible = false;
        rootNiveles.visible = true;

        var contenedorPopUp = rootNiveles.Q<VisualElement>("ContenedorPrincipal");
        if (contenedorPopUp != null)
            contenedorPopUp.visible = true;
    }

    private void CargarModoEndless()
    {
        InicializarInventario();
        GlobalVariables.endlessMode = true;
        SceneManager.LoadScene(2);
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

    private void InicializarInventario()
    {
        // Limpiar listas por si acaso
        InventarioManager.ListaObjetos.Clear();
        InventarioManager.InventarioJugador.Clear();

        // Objeto 1: Añade un corte de cuerda extra
        InventarioManager.AgregarObjeto(
            "Añade un corte de cuerda extra",
            "CORTE_EXTRA_1",
            50,
            "corte_extra_icon"
        );

        // Objeto 2: Cortes de cuerda infinito pero cada uno gasta una dona
        InventarioManager.AgregarObjeto(
            "Cortes de cuerda infinito (cada corte gasta una dona)",
            "CORTE_INFINITO",
            150,
            "infinito_icon"
        );

        // Objeto 3: Multiplica el número por donas siempre y cuando quede una cuerda sin cortar
        InventarioManager.AgregarObjeto(
            "Multiplica donas si queda cuerda sin cortar",
            "MULTIPLICADOR_DONAS",
            200,
            "multiplicador_icon"
        );

        // Objeto 4: Da un pequeño impulso a la galleta se pierde al usar
        InventarioManager.AgregarObjeto(
            "Pequeño impulso a la galleta (se consume al usar)",
            "IMPULSO_GALLETA",
            75,
            "impulso_icon"
        );

        // Objeto 5: Pierde una galleta sin problemas se destruye al usar
        InventarioManager.AgregarObjeto(
            "Permite perder una galleta sin problemas (se destruye al usar)",
            "PROTECCION_GALLETA",
            100,
            "proteccion_icon"
        );

        // Objeto 6: Reintenta el nivel se destruye al usar
        InventarioManager.AgregarObjeto(
            "Reintenta el nivel (se destruye al usar)",
            "REINTENTO_NIVEL",
            120,
            "reintento_icon"
        );
    }

    private void CargarTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
