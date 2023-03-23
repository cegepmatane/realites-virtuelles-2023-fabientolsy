using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionContact : MonoBehaviour
{

    protected gestionCube cube;
    protected float temps = 0;
    
    private void Start()
    {
        cube = transform.parent.gameObject.GetComponent<gestionCube>();
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.name == "hands:b_l_index3")
        {
            float tempsPresent = Time.time;
            Debug.Log("Temps depuis le debut: " + temps + ", Temps collision: " + tempsPresent);

            if (Time.deltaTime >= 2)
            {
                Debug.Log(collision.name + " est entre en collision avec " + this.gameObject.name);

                cube.afficher(this.gameObject.name);
            }
            else
            {
                Debug.Log("TROP RAPIDE ! Temps present: " + tempsPresent);
                tempsPresent = 0;
            }
        }

        else
        {
            Debug.Log("Collion impossible !");
        }
    }
}
