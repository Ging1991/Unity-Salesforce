using System.Collections.Generic;
using UnityEngine;

namespace Bounds.Cartas.Tinteros {

	public class TinteroBounds : ITintero {

		private Dictionary<string, Color> datos;
		private static readonly float DIVISOR = 255f;

		public TinteroBounds() {
			datos = new();

			datos[$"TINTA_ORO"] = new Color(0.3f, 0.2f, 0);
			datos[$"TINTA_PLA"] = new Color(190 / DIVISOR, 190 / DIVISOR, 180 / DIVISOR);
			datos[$"TINTA_MIT"] = new Color(150 / DIVISOR, 20 / DIVISOR, 10 / DIVISOR);
			datos[$"TINTA_N"] = Color.black;

			datos[$"NIVEL_ORO"] = new Color(240 / DIVISOR, 240 / DIVISOR, 40 / DIVISOR);
			datos[$"NIVEL_PLA"] = new Color(125 / DIVISOR, 125 / DIVISOR, 125 / DIVISOR);
			datos[$"NIVEL_MIT"] = new Color(250 / DIVISOR, 70 / DIVISOR, 70 / DIVISOR);
			datos[$"NIVEL_N"] = new Color(15 / DIVISOR, 200 / DIVISOR, 30 / DIVISOR);

			datos[$"RELLENO_CLARO_BASICO"] = new Color(240 / DIVISOR, 180 / DIVISOR, 80 / DIVISOR);
			datos[$"RELLENO_CLARO_SAGRADO"] = new Color(230 / DIVISOR, 190 / DIVISOR, 80 / DIVISOR);
			datos[$"RELLENO_CLARO_EVOLUCION"] = new Color(255 / DIVISOR, 75 / DIVISOR, 95 / DIVISOR);
			datos[$"RELLENO_CLARO_MISION"] = new Color(255 / DIVISOR, 75 / DIVISOR, 95 / DIVISOR);
			datos[$"RELLENO_CLARO_FUSION"] = new Color(100 / DIVISOR, 170 / DIVISOR, 230 / DIVISOR);
			datos[$"RELLENO_CLARO_MAGICO"] = new Color(220 / DIVISOR, 210 / DIVISOR, 210 / DIVISOR);
			datos[$"RELLENO_CLARO_VECTOR"] = new Color(120 / DIVISOR, 120 / DIVISOR, 120 / DIVISOR);
			datos[$"RELLENO_CLARO_GEMINIS"] = new Color(40 / DIVISOR, 200 / DIVISOR, 160 / DIVISOR);
			datos[$"RELLENO_CLARO_HECHIZO"] = new Color(200 / DIVISOR, 110 / DIVISOR, 250 / DIVISOR);
			datos[$"RELLENO_CLARO_ROMPECABEZAS"] = new Color(200 / DIVISOR, 110 / DIVISOR, 250 / DIVISOR);
			datos[$"RELLENO_CLARO_TRAMPA"] = new Color(160 / DIVISOR, 180 / DIVISOR, 180 / DIVISOR);
			datos[$"RELLENO_CLARO_EQUIPO"] = new Color(190 / DIVISOR, 110 / DIVISOR, 50 / DIVISOR);
			datos[$"RELLENO_CLARO_AURA"] = new Color(160 / DIVISOR, 250 / DIVISOR, 150 / DIVISOR);
			datos[$"RELLENO_CLARO_VACIO"] = new Color(135 / DIVISOR, 240 / DIVISOR, 240 / DIVISOR);
			datos[$"RELLENO_CLARO_REFLEJO"] = new Color(135 / DIVISOR, 240 / DIVISOR, 240 / DIVISOR);
			datos[$"RELLENO_CLARO_FANTASMA"] = new Color(240 / DIVISOR, 230 / DIVISOR, 120 / DIVISOR);
			datos[$"RELLENO_CLARO_FICHA"] = new Color(230 / DIVISOR, 170 / DIVISOR, 220 / DIVISOR);

			datos[$"RELLENO_SAGRADO"] = new Color(190 / DIVISOR, 130 / DIVISOR, 10 / DIVISOR);
			datos[$"RELLENO_BASICO"] = new Color(230 / DIVISOR, 110 / DIVISOR, 30 / DIVISOR);
			datos[$"RELLENO_EVOLUCION"] = new Color(235 / DIVISOR, 20 / DIVISOR, 20 / DIVISOR);
			datos[$"RELLENO_MISION"] = new Color(235 / DIVISOR, 20 / DIVISOR, 20 / DIVISOR);
			datos[$"RELLENO_FUSION"] = new Color(35 / DIVISOR, 30 / DIVISOR, 235 / DIVISOR);
			datos[$"RELLENO_MAGICO"] = new Color(130 / DIVISOR, 125 / DIVISOR, 125 / DIVISOR);
			datos[$"RELLENO_VECTOR"] = new Color(60 / DIVISOR, 60 / DIVISOR, 60 / DIVISOR);
			datos[$"RELLENO_GEMINIS"] = new Color(0 / DIVISOR, 140 / DIVISOR, 100 / DIVISOR);
			datos[$"RELLENO_HECHIZO"] = new Color(130 / DIVISOR, 70 / DIVISOR, 190 / DIVISOR);
			datos[$"RELLENO_ROMPECABEZAS"] = new Color(130 / DIVISOR, 70 / DIVISOR, 190 / DIVISOR);
			datos[$"RELLENO_TRAMPA"] = new Color(90 / DIVISOR, 90 / DIVISOR, 90 / DIVISOR);
			datos[$"RELLENO_EQUIPO"] = new Color(130 / DIVISOR, 60 / DIVISOR, 10 / DIVISOR);
			datos[$"RELLENO_AURA"] = new Color(30 / DIVISOR, 200 / DIVISOR, 15 / DIVISOR);
			datos[$"RELLENO_VACIO"] = new Color(20 / DIVISOR, 170 / DIVISOR, 200 / DIVISOR);
			datos[$"RELLENO_REFLEJO"] = new Color(20 / DIVISOR, 170 / DIVISOR, 200 / DIVISOR);
			datos[$"RELLENO_FANTASMA"] = new Color(220 / DIVISOR, 240 / DIVISOR, 30 / DIVISOR);
			datos[$"RELLENO_FICHA"] = new Color(240 / DIVISOR, 100 / DIVISOR, 215 / DIVISOR);
		}

		public Color GetColor(string clave) {
			if (datos.TryGetValue(clave, out var color))
				return color;

			Debug.LogWarning($"Color no encontrado: {clave}");
			return Color.white;
		}

	}

}