using System.Collections.Generic;
using UnityEngine;

public class Objeto {
    public string Descripcion { get; set; }
    public string IdObjeto { get; set; }
    public decimal Precio { get; set; }
    public string Icono { get; set; }
};

public static class InventarioManager {
    public static List<Objeto> ListaObjetos = new List<Objeto>();
    public static List<int> NumerosUnoADiez = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    public static List<Objeto> InventarioJugador = new List<Objeto>();
    
    public static void AgregarObjeto(string descripcion, string idObjeto, decimal precio, string icono) {
        Objeto nuevoObjeto = new Objeto
        {
            Descripcion = descripcion,
            IdObjeto = idObjeto,
            Precio = precio,
            Icono = icono
        };

        ListaObjetos.Add(nuevoObjeto);
    }
    
    // Método para agregar objetos al inventario del jugador
    public static void AgregarAlInventarioJugador(string idObjeto) {
        Objeto objetoAAgregar = ListaObjetos.Find(o => o.IdObjeto == idObjeto);
        if (objetoAAgregar != null) {
            InventarioJugador.Add(objetoAAgregar);
        }
    }
    
    // Método para remover objetos del inventario del jugador
    public static void RemoverDelInventarioJugador(string idObjeto) {
        Objeto objetoARemover = InventarioJugador.Find(o => o.IdObjeto == idObjeto);
        if (objetoARemover != null) {
            InventarioJugador.Remove(objetoARemover);
        }
    }
}