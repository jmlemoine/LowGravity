using UnityEngine;
using System.Collections;

public class ControladorJuego : MonoBehaviour {
	public void ReiniciarNivel()
	{
        if (Application.loadedLevelName == "LunarLanding")
        {
             Application.LoadLevel(1);
        }else if (Application.loadedLevelName == "LunarLanding2")
           Application.LoadLevel(3);
           else if (Application.loadedLevelName == "LunarLanding3")
           Application.LoadLevel(2);



    }

}
