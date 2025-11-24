using Bounds.Cartas.Tinteros;
using UnityEngine;

namespace Bounds.Cartas.Persistencia.Test {

	public class Controltest : MonoBehaviour {

		public DatosDeCartas datos;
		public IlustradorDeCartas ilustrador;
		public CartaFrente carta;

		public void PruebaDeDatos() {
			Debug.Log(datos.lector.LeerDatos(1).nombre);
			Debug.Log(DatosDeCartas.Instancia.lector.LeerDatos(1).nombre);
			Debug.Log(datos.lector.LeerDatos(1).clase);
		}


		void Start() {
			datos.Inicializar();
			//PruebaDeDatos();

			ilustrador.Inicializar();
			carta.Inicializar(datos, ilustrador, new TinteroBounds());
			carta.Mostrar(5);
		}

	}

}