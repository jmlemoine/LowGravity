using UnityEngine;
using System.Collections;

public class combustible : MonoBehaviour {

 

	void Start () {
	
	}

	void Update () {
	
	}

  
  

     void OnCollisionEnter2D(Collision2D colision) //captura de combustible
     {
         if (gameObject.tag == "Gas")
         {
            Destroy(gameObject);
      
            colision.gameObject.SendMessageUpwards("darGas");
         }
     }
}
