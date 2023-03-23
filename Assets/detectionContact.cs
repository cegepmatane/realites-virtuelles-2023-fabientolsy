using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionContact : MonoBehaviour
{

    protected gestionCube cube;
    protected float temps;
    
    private void Start()
    {
        cube = transform.parent.gameObject.GetComponent<gestionCube>();
        
    }
    private void OnTriggerEnter(Collider collision)
    {        
        if (collision.name == "hands:b_l_index3" && Time.time - temps >= 5f)
        {
            Debug.LogWarning("Temps depuis le debut: " + temps );
            Debug.Log(collision.name + " est entre en collision avec " + this.gameObject.name);

            cube.afficher(this.gameObject.name);     
        }

        else
        {
            Debug.Log("COLLISION IMPOSSIBLE / TROP RAPIDE!");
        }

        temps = Time.time;
    }
}
