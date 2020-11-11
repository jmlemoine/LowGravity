using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObjetivoJugador : MonoBehaviour {

	private bool contraerPistaAterrizaje;
	private bool contactoHecho;
	private Jugador naveJugador;
   

	// Use this for initialization
	void Start () {
		naveJugador = GameObject.Find ("Lander").GetComponent<Jugador> ();
		
	}

	public void ActivarAterrizaje()
	{
	
		if (contraerPistaAterrizaje == false && contactoHecho == false) {
			StartCoroutine (EsconderPies());
            if (Application.loadedLevelName == "LunarLanding")
                SceneManager.LoadScene("LunarLandinglevel2");



        }
        
        
	}

	private IEnumerator EsconderPies()
	{
		contraerPistaAterrizaje = true;
		contactoHecho = true;
		yield return new WaitForSeconds (0.5f); //yield indica que lo que recibe el metodo como accesor u operador es un iterador.
		contraerPistaAterrizaje = false;
		naveJugador.propulsorActivado = false;
		GameObject.Find ("Lander").GetComponent<Jugador>().ActivarBotonReinicio ();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
	
}
