using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

    public Camera camara;
	public GameObject exploxionPrefab;

	public GameObject piesNave;
    private bool piesDesplegados;

    public bool propulsorActivado; 
	

    public float gas;
    public Text textoGas; //texto combustible

    private bool sonidoPropulsorActivado; //sonido de propulsion

    //Animacion de propulsion
    public Animator animacionPropulsorCentral;
	public Animator animacionPropulsorIzq;
	public Animator animacionPropulsorDer;
	public AudioSource audioPropulsor;

    public Transform propulsorCentral;
    public Transform propulsorIzq;
    public Transform propulsorDer;

    public float poderPropulsorCentral;
    public float poderPropulsorLateral;

    private GameObject objetivoNave; 

	private Rigidbody2D jugadorRB; 

	private HingeJoint2D unionPies; // permite que un objeto con rigidbody rote respecto a un punto.

	private Button botonReinicio;

    public GameObject GameOverEffect;
    // Use this for initialization
    void Start () {
       

		jugadorRB = GetComponent<Rigidbody2D> ();
        gas = 15;
		objetivoNave = GameObject.Find ("LanderObjective");
		unionPies = transform.Find ("LanderFeet").GetComponent<HingeJoint2D>();
		botonReinicio = GameObject.Find ("RestartButton").GetComponent<Button> ();
		botonReinicio.onClick.AddListener (Reinicio);
	}

	void Reinicio()
	{
		botonReinicio.gameObject.GetComponent<Image> ().enabled = false;
		botonReinicio.gameObject.transform.Find ("Text").GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        
        //Despliegue de los pies de la nave
        var distanciaObjetivo = Vector2.Distance (transform.position, objetivoNave.transform.position);
		if (distanciaObjetivo <= 1.8f && piesDesplegados == false) //Distancia a la que despliega la base de aterrizaje
		{
			piesDesplegados = true;
		}

		if (piesDesplegados == true) 
		{
			var piesNavePosY = unionPies.anchor.y + Time.deltaTime / 3;

			if (piesNavePosY < 0.38f) {
				unionPies.anchor = new Vector2 (0f, piesNavePosY);
			} else {
				piesDesplegados = false;
			}
		}

		//Activar sonidos
		if (sonidoPropulsorActivado == true) {
			TocarSonidoPropulsor ();
		} else {
			audioPropulsor.Pause ();
		}
	}

	void FixedUpdate() //Movimiento de la nave y animacion de propulsion 
	{
		sonidoPropulsorActivado = false;

		//Movimiento de la nave
		if (Input.GetAxis ("Vertical") > 0) {
			sonidoPropulsorActivado = true;
			AplicandoFuerza (propulsorCentral, poderPropulsorCentral);
			if (animacionPropulsorCentral != null && animacionPropulsorCentral.runtimeAnimatorController != null) { //al pulsar arriba
				animacionPropulsorCentral.SetBool ("ActivandoPropulsor", true);
			}
		} else {
			if (animacionPropulsorCentral != null && animacionPropulsorCentral.runtimeAnimatorController != null) {
				animacionPropulsorCentral.SetBool ("ActivandoPropulsor", false);
			}
		}

		if (Input.GetAxis ("Horizontal") > 0) {
			sonidoPropulsorActivado = true;
			AplicandoFuerza (propulsorIzq, poderPropulsorLateral);
			if (animacionPropulsorIzq != null && animacionPropulsorIzq.runtimeAnimatorController != null) { //al pulsa derecha
                animacionPropulsorCentral.SetBool("ActivandoPropulsor", true);
            }
		} else {
			if (animacionPropulsorIzq != null && animacionPropulsorIzq.runtimeAnimatorController != null) {
              
            }
		}

		if (Input.GetAxis ("Horizontal") < 0) {
			sonidoPropulsorActivado = true;
			AplicandoFuerza (propulsorDer, poderPropulsorLateral);
			if (animacionPropulsorDer != null && animacionPropulsorDer.runtimeAnimatorController != null) { //al pulsa izquierda
                animacionPropulsorCentral.SetBool("ActivandoPropulsor", true);
            }
		} else {
			if (animacionPropulsorDer != null && animacionPropulsorDer.runtimeAnimatorController != null) {
               
            }
		}

	}


	private void TocarSonidoPropulsor() //Sonido propulsion
	{
		if (audioPropulsor.isPlaying) {
			return;
		}

		audioPropulsor.Play ();
	}

	void AplicandoFuerza(Transform propulsorTransform, float poderPropulsor) //Movimiento y contador de gasolina
	{
		if (propulsorActivado && gas > 0f) {
			//Aplicando la fuerza a la nave para simular el movimiento
			Vector3 direccion = transform.position - propulsorTransform.position;
			jugadorRB.AddForceAtPosition (direccion.normalized * poderPropulsor, propulsorTransform.position);

            //El movimiento disminuye el combustible
			gas -= 0.01f;
			textoGas.text = "Combustible " + Mathf.Round (gas);
		}
	}

	private void OnCollisionEnter2D(Collision2D colision) //Colison segun la velocidad
	{

		if (colision.relativeVelocity.magnitude > 3) {

            DestructorNave ();
		} else if (colision.relativeVelocity.magnitude > 1) {
           
            DestructorNave ();
		}
       
    }

    private void DestructorNave()
	{
		if (exploxionPrefab != null) {
			var explocion = Instantiate (exploxionPrefab, transform.position, Quaternion.identity) as GameObject;
			Destroy (explocion, 1f);
		}
        Instantiate(GameOverEffect, transform.position, transform.rotation);
        Destroy (gameObject);
		ActivarBotonReinicio ();
	}

	public void ActivarBotonReinicio() //boton de reinicio
	{
		botonReinicio.gameObject.GetComponent<Image> ().enabled = true;
		botonReinicio.gameObject.transform.Find ("Text").GetComponent<Text> ().enabled = true;
     
            botonReinicio.gameObject.transform.Find("Text").GetComponent<Text>().text = "Volver a Jugar";

    }

    public void darGas() //suma de combustible
    {
        gas += 10;
    }
}
