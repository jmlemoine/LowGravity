using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroide : MonoBehaviour
{
    public float Velocidad = 3;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.velocity = Vector3.down * Velocidad + Vector3.left * Random.Range(-1, -1);
        rb2d.velocity = Vector3.down * Velocidad;
		
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1);
    }
}
