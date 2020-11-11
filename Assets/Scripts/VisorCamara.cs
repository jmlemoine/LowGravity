using UnityEngine;
using System.Collections;

public class VisorCamara : MonoBehaviour {

	public Transform camaraFijaObjetivo;

	public float velocidadSeguimiento;
	public float profundidadCamaraZ = -10f;
	public float minX;
	public float minY;
	public float maxX;
	public float maxY;
    bool estaCreado;
    int j;
  

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 campos = transform.position;

		if (camaraFijaObjetivo != null) {
			var nuevaPosicion = Vector2.Lerp(transform.position, camaraFijaObjetivo.transform.position, Time.deltaTime * velocidadSeguimiento);
			var posicionCamara = new Vector3(nuevaPosicion.x,nuevaPosicion.y, profundidadCamaraZ);

				var var3 = posicionCamara;
				var nuevaX = Mathf.Clamp(var3.x,minX,maxX);
				var nuevaY = Mathf.Clamp(var3.y,minY,maxY);
				transform.position = new Vector3(nuevaX,nuevaY,profundidadCamaraZ);
		}
	}

 
}
