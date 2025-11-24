using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Ging1991.Interfaces;
using Bounds.Cartas.Persistencia.Datos;
using Bounds.Cartas.Persistencia;
using Bounds.Cartas.Tinteros;

namespace Bounds.Global.Visores {

	public class Visor : MonoBehaviour {

		public GameObject ilustracionOBJ;
		public GameObject reversoOBJ;

		private IlustradorDeCartas ilustrador;
		private DatosDeCartas datos;
		private ITintero tintero;

		public void Inicializar(DatosDeCartas datos, IlustradorDeCartas ilustrador, ITintero tintero) {
			this.ilustrador = ilustrador;
			this.datos = datos;
			this.tintero = tintero;
		}


		public void SetBocaAbajo(bool estaBocaAbajo, Sprite reversoIMG) {
			Image image = reversoOBJ.GetComponent<Image>();
			if (estaBocaAbajo) {
				image.sprite = reversoIMG;
				image.color = Color.white;
			}
			else {
				image.sprite = null;
				image.color = Color.clear;
			}
		}


		public void SetImagen(int cartaID, string imagen) {
			//Ilustrador lector = Ilustrador.GetInstancia();
			//ilustracionOBJ.GetComponent<Image>().sprite = lector.GetImagen(cartaID, imagen);
		}


		public void SetFondo(Color fondo, Color tinta) {
			GetComponent<Marco>().SetColorBorde(tinta);
			GetComponent<Marco>().SetColorRelleno(fondo);
		}


		public void SetSubFondo(string clase, string rareza = "N") {
			//GetComponentInChildren<VisorTitulo>().SetFondo(VisorTinta.GetColorDeTinta(rareza), VisorTinta.GetColorDeFondoClaro(clase));
			//GetComponentInChildren<VisorDescripcion>().SetFondo(VisorTinta.GetColorDeTinta(rareza), VisorTinta.GetColorDeFondoClaro(clase));
		}


		public void SetDescripcion(string encabezado, string materiales, string habilidades, string efecto) {
			string texto = "";
			texto += encabezado;
			texto += materiales;
			texto += (efecto != "" && efecto != null) ? $"{efecto}\n" : "";
			texto += habilidades;
			GetComponentInChildren<VisorDescripcion>().SetDescripcion(texto);
		}


		public string GenerarEncabezado(string clase, string perfeccion = "", List<string> tipos = null) {

			if (clase != "CRIATURA" && clase != "CREATURE")
				return $"[{clase}]\n";

			string tiposDeCriatura = "";
			foreach (string tipo in tipos)
				tiposDeCriatura += char.ToUpper(tipo[0]) + tipo.Substring(1) + " ";

			return $"[{clase} {perfeccion}/ {tiposDeCriatura.Trim()}]\n";
		}


		public string GenerarMateriales(List<MaterialBD> materialesOBJ) {
			if (materialesOBJ.Count == 0)
				return "";

			List<string> materiales = new List<string>();

			foreach (var material in materialesOBJ) {
				if (material.tipo == "CLASE")
					materiales.Add(material.parametroClase);

				if (material.tipo == "TIPO")
					materiales.Add(material.parametroTipo);

				if (material.tipo == "CARTA_ID")
					materiales.Add(DatosDeCartas.Instancia.lector.LeerDatos(material.parametroID).nombre);

				if (material.tipo == "VECTOR_ATK")
					materiales.Add($"ATK{material.parametroATK}");

				if (material.tipo == "VECTOR_DEF")
					materiales.Add($"DEF{material.parametroDEF}");
			}

			return $"<b>Materiales:</b> {string.Join(" + ", materiales)}\n";
		}


		public string Generarhabilidades(List<EfectoBD> habilidades) {
			//LectorHabilidades lector = LectorHabilidades.GetInstancia();

			if (habilidades.Count > 3) {
				List<string> nombres = new List<string>();
				foreach (var habilidad in habilidades) {
					//nombres.Add(lector.LeerNombre(habilidad.clave));
				}
				return String.Join(". ", nombres);
			}

			string habilidadesRet = "";/*
			foreach (var habilidad in habilidades) {
				if (!habilidad.clave.StartsWith("especial")) {
					habilidadesRet += $"• <b>{lector.LeerNombre(habilidad.clave)}:</b> {lector.LeerDescripcion(habilidad.clave)}\n";
					if (habilidad.parametroID > 0)
						habilidadesRet = habilidadesRet.Replace("[ID]", $"{DatosDeCartas.Instancia.lector.LeerDatos(habilidad.parametroID).nombre}");
					if (habilidad.parametroN > 0)
						habilidadesRet = habilidadesRet.Replace("[N]", $"{habilidad.parametroN}");
					if (habilidad.parametroTipo != "")
						habilidadesRet = habilidadesRet.Replace("[TIPO]", $"{habilidad.parametroTipo}");
					if (habilidad.parametroPerfeccion != "")
						habilidadesRet = habilidadesRet.Replace("[PERFECCION]", $"{habilidad.parametroPerfeccion}");
					if (habilidad.parametroZona != "")
						habilidadesRet = habilidadesRet.Replace("[ZONA]", $"{habilidad.parametroZona}");
					if (habilidad.parametroHabilidad != "")
						habilidadesRet = habilidadesRet.Replace("[HABILIDAD]", $"{habilidad.parametroHabilidad}");
					if (habilidad.parametroNMaximo != 0)
						habilidadesRet = habilidadesRet.Replace("[MAXIMO]", $"{habilidad.parametroNMaximo}");
					if (habilidad.parametroNMinimo != 0)
						habilidadesRet = habilidadesRet.Replace("[MINIMO]", $"{habilidad.parametroNMinimo}");
					if (habilidad.parametroATK != 0)
						habilidadesRet = habilidadesRet.Replace("[ATK]", $"{habilidad.parametroATK}");
					if (habilidad.parametroDEF != 0)
						habilidadesRet = habilidadesRet.Replace("[DEF]", $"{habilidad.parametroDEF}");
					if (habilidad.parametroClase != "")
						habilidadesRet = habilidadesRet.Replace("[C]", $"{habilidad.parametroClase}");
				}

			}
*/
			return habilidadesRet;
		}


	}

}