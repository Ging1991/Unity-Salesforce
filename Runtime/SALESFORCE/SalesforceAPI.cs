using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Threading.Tasks;

namespace Ging1991.Salesforce {

	public abstract class SalesforceAPI {

		private readonly Credencial credencial;
		private string token;
		private string instancia;

		public SalesforceAPI(Credencial credencial) {
			this.credencial = credencial;
		}


		public async Task<bool> AutorizarAsincronico() {

			WWWForm formulario = new();
			formulario.AddField("grant_type", "password");
			formulario.AddField("client_id", credencial.clienteID);
			formulario.AddField("client_secret", credencial.clienteSecreto);
			formulario.AddField("username", credencial.usuario);
			formulario.AddField("password", credencial.password + credencial.tokenPersonal);

			using UnityWebRequest solicitud = UnityWebRequest.Post(credencial.URL, formulario);
			var operacion = solicitud.SendWebRequest();

			while (!operacion.isDone)
				await Task.Yield();

			if (solicitud.result == UnityWebRequest.Result.Success) {
				Autorizacion autorizacion = JsonUtility.FromJson<Autorizacion>(solicitud.downloadHandler.text);
				token = autorizacion.access_token;
				instancia = autorizacion.instance_url;
				return true;
			}
			else {
				return false;
			}
		}


		protected async Task<string> CrearSolicitudAsincronica(string servicio, string parametros) {

			if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(instancia)) {
				Debug.LogError("No hay token o instancia. Llama a AutorizarAsync primero.");
				return null;
			}

			string url = instancia.TrimEnd('/') + "/" + servicio.TrimStart('/');
			byte[] bodyRaw = Encoding.UTF8.GetBytes(parametros);

			using (UnityWebRequest solicitud = new UnityWebRequest(url, "POST")) {

				solicitud.uploadHandler = new UploadHandlerRaw(bodyRaw);
				solicitud.downloadHandler = new DownloadHandlerBuffer();
				solicitud.SetRequestHeader("Authorization", "Bearer " + token);
				solicitud.SetRequestHeader("Content-Type", "application/json");

				var operacion = solicitud.SendWebRequest();
				while (!operacion.isDone)
					await Task.Yield();

				if (solicitud.result == UnityWebRequest.Result.Success) {
					return solicitud.downloadHandler.text;
				}
				else {
					Debug.LogError("Error al llamar a Salesforce: " + solicitud.error);
					return null;
				}
			}
		}

	}

}