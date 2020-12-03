﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Distancia : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Lander;
    public GameObject LanderObjective;
    public float distancia_;
    public Text TextDistancia;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*Transform lanTarget = Lander.transform;
        Transform lanOTarget = LanderObjective.transform;*/

        distancia_ = Vector2.Distance(/*lanTarget.position*/Lander.transform.position, /*lanOTarget.position*/LanderObjective.transform.position);
        setDistance();
    }
    void setDistance()
    {
        int distancia_entero = (int) Math.Round(distancia_);
        TextDistancia.text = distancia_entero.ToString();
    }
}
