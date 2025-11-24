using Bounds.Cartas.Persistencia;
using Bounds.Cartas.Persistencia.Datos;
using Bounds.Cartas.Tinteros;

namespace Bounds.Cartas {

	public class CartaFrente : CartaFrenteBase {

		private IlustradorDeCartas ilustrador;
		private DatosDeCartas datos;
		private ITintero tintero;

		public void Inicializar(DatosDeCartas datos, IlustradorDeCartas ilustrador, ITintero tintero) {
			this.ilustrador = ilustrador;
			this.datos = datos;
			this.tintero = tintero;
		}


		public void Mostrar(int cartaID, string imagen = "A", string rareza = "N") {

			SetIlustracion(ilustrador.lector.GetImagen(cartaID, imagen));
			CartaBD dato = datos.lector.LeerDatos(cartaID);

			SetNivel(dato.nivel, tintero.GetColor($"NIVEL_{rareza}"));
			SetColorBorde(tintero.GetColor($"TINTA_{rareza}"));

			if (dato.clase == "CRIATURA")
				SetEstadisticas(dato.datoCriatura.ataque, dato.datoCriatura.defensa);
			else if (dato.clase == "EQUIPO")
				SetEstadisticas(dato.defensa);
			else
				SetEstadisticas();

			string borde = dato.clase == "CRIATURA" ? dato.datoCriatura.perfeccion : dato.clase;
			SetFondo(tintero.GetColor($"RELLENO_{borde}"), tintero.GetColor($"RELLENO_CLARO_{borde}"));
		}

	}

}