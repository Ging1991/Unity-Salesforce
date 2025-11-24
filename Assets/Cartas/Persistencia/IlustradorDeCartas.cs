using UnityEngine;

namespace Bounds.Cartas.Persistencia {

	public class IlustradorDeCartas : MonoBehaviour {

		public string direccion;
		public LectorIlustraciones lector;

		public void Inicializar() {
			lector = new(direccion);
		}


	}

}