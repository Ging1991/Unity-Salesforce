using Ging1991.Animaciones.Efectos;
using Ging1991.Relojes;
using UnityEngine;
using UnityEngine.UI;

namespace Bounds.Cartas {

	public class CartaFisica : MonoBehaviour, IEjecutable {

		public GameObject cartaFrenteOBJ;
		public GameObject cartaReversoOBJ;
		public Rotar rotacion1;
		public Rotar rotacion2;
		public Rotar girar;
		public Rotar enderezar;
		private bool estaAbajo = false;
		public Escalar escalar1;
		public Escalar escalar2;

		public void Acercar() {
			escalar1.Inicializar();
		}

		public void Alejar() {
			escalar2.Inicializar();
		}


		public void Girar() {
			girar.Inicializar();
		}

		public void Enderezar() {
			enderezar.Inicializar();
		}


		public void ColocarBocaAbajo(bool inmediato = true) {
			if (!estaAbajo) {
				estaAbajo = true;
				if (inmediato) {
					cartaFrenteOBJ.SetActive(!estaAbajo);
					cartaReversoOBJ.SetActive(estaAbajo);
				}
				else {
					rotacion1.accionFinal = this;
					rotacion1.Inicializar();
				}
			}
		}


		public void ColocarBocaArriba(bool inmediato = true) {
			if (estaAbajo) {
				estaAbajo = false;
				if (inmediato) {
					cartaFrenteOBJ.SetActive(!estaAbajo);
					cartaReversoOBJ.SetActive(estaAbajo);
				}
				else {
					rotacion1.accionFinal = this;
					rotacion1.Inicializar();
				}
			}
		}


		public Sprite GetReverso() {
			return cartaReversoOBJ.GetComponent<Image>().sprite;
		}


		public void SetReverso(Sprite sprite) {
			cartaReversoOBJ.GetComponent<Image>().sprite = sprite;
		}


		public CartaFrente GetCartaFrente() {
			return cartaFrenteOBJ.GetComponent<CartaFrente>();
		}


		public void Ejecutar() {
			cartaFrenteOBJ.SetActive(!estaAbajo);
			cartaReversoOBJ.SetActive(estaAbajo);
			rotacion2.Inicializar();
		}


	}

}