using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EndlessChoseLevel : MonoBehaviour
{
    private Button btnSiguiente;
    private Button btnComprar;
    private UIDocument uIDocumentCreditos;
    private VisualElement rootCreditos;
    private VisualElement rootNiveles;
    private Label descripcionObjeto;
    private VisualElement iconoObjeto;
    private Label precioObjeto;
    
    private int ultimoNivel = -1;
    private Objeto objetoActual;

    void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        // Obtener referencias a los elementos UI
        btnSiguiente = root.Q<Button>("SiguienteRondaBoton");
        btnComprar = root.Q<Button>("ComprarBoton");
        descripcionObjeto = root.Q<Label>("Descripcion");
        iconoObjeto = root.Q<VisualElement>("Icon");
        precioObjeto = root.Q<Label>("Precio");
        
        btnSiguiente.clicked += CargarSiguienteNivel;
        btnComprar.clicked += ComprarObjeto;
        
        // Mostrar un objeto aleatorio al iniciar
        MostrarObjetoAleatorio();
    }
    
    private void MostrarObjetoAleatorio() {
        if (InventarioManager.ListaObjetos.Count > 0) {
            // Seleccionar un objeto aleatorio
            int indiceAleatorio = Random.Range(0, InventarioManager.ListaObjetos.Count);
            objetoActual = InventarioManager.ListaObjetos[indiceAleatorio];
            
            // Actualizar la UI con los datos del objeto
            descripcionObjeto.text = objetoActual.Descripcion;
            precioObjeto.text = $": {objetoActual.Precio}";
            
            // Aquí deberías cargar el icono del objeto
            // Ejemplo: iconoObjeto.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(objetoActual.Icono));
        } else {
            descripcionObjeto.text = "No hay objetos disponibles";
            precioObjeto.text = "";
        }
    }
    
    private void ComprarObjeto() {
        if (objetoActual != null) {
            // Aquí deberías verificar si el jugador tiene suficiente dinero
            // y luego agregar el objeto al inventario
            
            InventarioManager.AgregarAlInventarioJugador(objetoActual.IdObjeto);
            Debug.Log($"Objeto comprado: {objetoActual.Descripcion}");
            
            // Mostrar un nuevo objeto aleatorio después de comprar
            MostrarObjetoAleatorio();
        }
    }
    
    private void CargarSiguienteNivel()  {
        int indiceAleatorio;
        do {
            indiceAleatorio = Random.Range(0, InventarioManager.NumerosUnoADiez.Count);
        } while (InventarioManager.NumerosUnoADiez[indiceAleatorio] == ultimoNivel);
        
        ultimoNivel = InventarioManager.NumerosUnoADiez[indiceAleatorio];
        SceneManager.LoadScene("Nivel" + ultimoNivel);
    }
    
    void OnDisable() {
        btnSiguiente.clicked -= CargarSiguienteNivel;
        btnComprar.clicked -= ComprarObjeto;
    }
}


