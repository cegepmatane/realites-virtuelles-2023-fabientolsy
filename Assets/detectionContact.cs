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
        if ((collision.name == "Left Hand" || collision.name == "Right Hand") && Time.time - temps >= .5f)
        {
            Debug.LogWarning("Temps depuis le debut: " + temps );
            Debug.Log(collision.name + " est entre en collision avec " + this.gameObject.name);

            cube.afficher(this.gameObject.name);
            temps = Time.time;

        }

        else
        {
            Debug.Log("COLLISION IMPOSSIBLE / TROP RAPIDE!");
            Debug.Log("Collision avec " + collision);
        }

    }
}
