using UnityEngine;
using UnityEngine.UIElements;

public class UICreditos : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocumentMenu; // Asigna desde el inspector
    private Button btnVolver;
    private VisualElement contenedorPopUp;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        contenedorPopUp = root.Q<VisualElement>("ContenedorPrincipal");
        btnVolver = root.Q<Button>("CloseButton");
        btnVolver.clicked += Volver;
        contenedorPopUp.visible = false;
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




