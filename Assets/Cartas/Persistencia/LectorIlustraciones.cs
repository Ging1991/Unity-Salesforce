using Ging1991.Persistencia.Direcciones;
using Ging1991.Persistencia.Lectores;
using Ging1991.Persistencia.Lectores.Demandas;
using UnityEngine;

namespace Bounds.Cartas.Persistencia {

	public class LectorIlustraciones : LectorPorDemandaImagen {

		public LectorIlustraciones(string direccion) : base(new DireccionRecursos(direccion), TipoLector.RECURSOS) { }


		public Sprite GetImagen(int cartaID, string alternativa = "") {
			alternativa = (alternativa == "A") ? "" : alternativa;

			Sprite ret = Leer($"carta{cartaID}{alternativa}");
			if (ret == null) {
				//				ret = DriveManager.CargarImagen($"carta{cartaID}{alternativa}");
			}
			return ret;
		}


	}

}