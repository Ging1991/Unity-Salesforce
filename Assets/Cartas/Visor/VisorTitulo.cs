using Ging1991.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Bounds.Global.Visores {

	public class VisorTitulo : MonoBehaviour {

		public GameObject fondoNivelOBJ;
		public GameObject textoNivelOBJ;
		public GameObject textoNombreOBJ;
		public GameObject textoCartaIDOBJ;

		public void SetNivel(int nivel, Color fondo, Color tinta) {
			textoNivelOBJ.GetComponent<Text>().text = $"{nivel}";
			textoNivelOBJ.GetComponent<Text>().color = tinta;
			fondoNivelOBJ.GetComponent<Image>().color = fondo;
		}


		public void SetCartaID(int cartaID, Color tinta) {
			textoCartaIDOBJ.GetComponent<Text>().text = $"| {cartaID}";
			textoCartaIDOBJ.GetComponent<Text>().color = tinta;
		}


		public void SetFondo(Color tinta, Color fondo) {
			GetComponent<Marco>().SetColorBorde(tinta);
			GetComponent<Marco>().SetColorRelleno(fondo);
		}


		public void SetNombre(string nombre, Color tinta) {
			textoNombreOBJ.GetComponent<Text>().text = nombre;
			textoNombreOBJ.GetComponent<Text>().color = tinta;
		}


	}

}