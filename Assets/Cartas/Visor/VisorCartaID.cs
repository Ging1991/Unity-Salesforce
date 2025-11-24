using System.Collections.Generic;
using Bounds.Cartas.Persistencia;
using Bounds.Cartas.Persistencia.Datos;
using Ging1991.Idiomas;
using UnityEngine;

namespace Bounds.Global.Visores {

	public class VisorCartaID : MonoBehaviour {

		public void Mostrar(int cartaID, string imagen, string rareza = "N") {

			Visor visor = GetComponentInChildren<Visor>();
			VisorTitulo visorTitulo = GetComponentInChildren<VisorTitulo>();
			VisorDescripcion visorDescripcion = GetComponentInChildren<VisorDescripcion>();

			CartaBD carta = DatosDeCartas.Instancia.lector.LeerDatos(cartaID);
			//Color tinta = VisorTinta.GetColorDeTinta(rareza);
			//Color colorNivel = VisorTinta.GetColorDeFondoNivel(rareza);

			visor.SetImagen(cartaID, imagen);
			/*
						visorTitulo.SetNivel(carta.nivel, colorNivel, tinta);
						visorTitulo.SetNombre(carta.nombre, tinta);
						visorTitulo.SetCartaID(carta.cartaID, tinta);
			*/
			string clase = carta.clase != "CRIATURA" ? carta.clase : carta.datoCriatura.perfeccion;
			//visor.SetFondo(VisorTinta.GetColorDeFondoOscuro(clase), tinta);
			visor.SetSubFondo(clase, rareza);

			if (clase == "EQUIPO")
				visorDescripcion.SetEstadisticas(carta.defensa);
			else if (carta.clase == "CRIATURA")
				visorDescripcion.SetEstadisticas(carta.datoCriatura.ataque, carta.datoCriatura.defensa);
			else
				visorDescripcion.SetEstadisticas();

			IdiomaFactory idiomaFactory = FindAnyObjectByType<IdiomaFactory>();
			Idioma idiomaClases = idiomaFactory.GetIdiomaClases();
			Idioma idiomaPerfecciones = idiomaFactory.GetIdiomaPerfecciones();
			Idioma idiomaTipos = idiomaFactory.GetIdiomaTipos();

			List<string> tiposTraducidos = new List<string>();
			if (carta.clase == "CRIATURA") {
				foreach (var tipo in carta.datoCriatura.tipos) {
					tiposTraducidos.Add(idiomaTipos.GetTraduccion(tipo));
				}
			}


			string encabezado = "";
			if (carta.clase == "CRIATURA")
				encabezado = visor.GenerarEncabezado(
					idiomaClases.GetTraduccion(carta.clase),
					idiomaPerfecciones.GetTraduccion(carta.datoCriatura.perfeccion),
					carta.datoCriatura.tipos
				);
			else
				encabezado = visor.GenerarEncabezado(idiomaClases.GetTraduccion(clase));

			string habilidades = visor.Generarhabilidades(carta.efectos);

			if (carta.clase == "CRIATURA" && carta.datoCriatura.efectos != null)
				habilidades += visor.Generarhabilidades(carta.datoCriatura.efectos);

			string efecto = carta.efecto;

			string materiales = "";
			if (carta.clase == "CRIATURA")
				materiales += visor.GenerarMateriales(carta.materiales);
			visor.SetDescripcion(encabezado, materiales, habilidades, efecto);
		}

	}

}