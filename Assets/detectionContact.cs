using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionContact : MonoBehaviour
{

    protected gestionCube cube;
    
    private void Start()
    {
        cube = transform.parent.gameObject.GetComponent<gestionCube>();
    }
    private void OnTriggerEnter(Collider collision)
    { 
        Debug.Log(collision.name + " est entre en collision avec " + this.gameObject.name);

        cube.afficher(this.gameObject.name);
    }
}
