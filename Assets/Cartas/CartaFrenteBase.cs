using Ging1991.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Bounds.Cartas {

	public abstract class CartaFrenteBase : MonoBehaviour {

		public GameObject ilustracionOBJ;
		public GameObject fondoOBJ;
		public GameObject nivelOBJ;
		public GameObject ataqueOBJ;
		public GameObject defensaOBJ;

		public void SetNivel(int nivel) {
			nivelOBJ.GetComponent<ContadorNumero>().SetValor(nivel);
		}


		public void SetNivel(int nivel, Color color) {
			nivelOBJ.GetComponent<ContadorNumero>().SetValor(nivel);
			nivelOBJ.GetComponent<ContadorNumero>().SetColorRelleno(color);
		}


		public void SetIlustracion(Sprite imagen) {
			ilustracionOBJ.GetComponent<Image>().sprite = imagen;
		}


		public void SetIlustracionColor(Color color) {
			ilustracionOBJ.GetComponent<Image>().color = color;
		}


		public void SetFondo(Color rellenoFondo, Color rellenoEstadisticas) {
			fondoOBJ.GetComponent<Marco>().SetColorRelleno(rellenoFondo);
			ataqueOBJ.GetComponent<ContadorNumero>().SetColorRelleno(rellenoEstadisticas);
			defensaOBJ.GetComponent<ContadorNumero>().SetColorRelleno(rellenoEstadisticas);
		}


		public void SetColorBorde(Color color) {
			GetComponent<Image>().color = color;
			fondoOBJ.GetComponent<Marco>().SetColorBorde(color);
		}


		public void SetEstadisticas() {
			ataqueOBJ.SetActive(false);
			defensaOBJ.SetActive(false);
		}


		public void SetEstadisticas(int defensa) {
			SetEstadisticas(defensaOBJ, true, defensa);
			ataqueOBJ.SetActive(false);
		}


		public void SetEstadisticas(int ataque, int defensa) {
			SetEstadisticas(ataqueOBJ, true, ataque);
			SetEstadisticas(defensaOBJ, true, defensa);
		}


		private void SetEstadisticas(GameObject objeto, bool activado, int valor = -1) {
			objeto.SetActive(activado);
			objeto.GetComponent<ContadorNumero>().SetValor(valor);
		}

	}

}