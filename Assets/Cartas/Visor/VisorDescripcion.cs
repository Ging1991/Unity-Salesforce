using Ging1991.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Bounds.Global.Visores {

	public class VisorDescripcion : MonoBehaviour {

		public GameObject explicacionOBJ;
		public GameObject estadisticasOBJ;

		public void SetDescripcion(string descripcion) {
			 explicacionOBJ.GetComponent<Text>().text = descripcion;
		}


		public void SetEstadisticas(int ataque, int defensa) {
			estadisticasOBJ.GetComponent<Text>().text = $"____________________\nATK {ataque}/ DEF {defensa}";
		}


		public void SetEstadisticas(int defensa) {
			estadisticasOBJ.GetComponent<Text>().text = $"____________________\nDEF {defensa}";
		}


		public void SetEstadisticas() {
			estadisticasOBJ.GetComponent<Text>().text = "";
		}


		public void SetFondo(Color tinta, Color fondo) {
			GetComponent<Marco>().SetColorBorde(tinta);
			GetComponent<Marco>().SetColorRelleno(fondo);
		}


	}

}