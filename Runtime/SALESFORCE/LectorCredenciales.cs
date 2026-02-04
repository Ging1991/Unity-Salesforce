using Ging1991.Persistencia.Lectores;

namespace Ging1991.Salesforce {

	public class LectorCredenciales : LectorGenerico<Credencial> {

		public LectorCredenciales(string direccion) : base(direccion, TipoLector.RECURSOS) { }

	}

}