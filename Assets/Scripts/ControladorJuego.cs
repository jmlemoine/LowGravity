using UnityEngine;
using System.Collections;

public class ControladorJuego : MonoBehaviour {
	public void ReiniciarNivel()
	{
        if (Application.loadedLevelName == "LunarLanding")
        {

            Application.LoadLevel(0);
        }

        //else if (Application.loadedLevelName == "LunarLanding")
        //    Application.LoadLevel(0);



    }

}
