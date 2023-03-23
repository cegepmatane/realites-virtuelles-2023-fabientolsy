using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoutonVR : MonoBehaviour
{

    public GameObject bouton;
    public UnityEvent enPression;
    public UnityEvent onRelease;
    GameObject presser;
    bool estPresse;
    // Start is called before the first frame update
    void Start()
    {
        estPresse = false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!estPresse) 
        {
            bouton.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            enPression.Invoke();
            estPresse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser) 
        {
        bouton.transform.localPosition = new Vector3(0, 0.015f,0);
            onRelease.Invoke();
            estPresse = false;

        }
    }

    public void ApparitionSphere()
    {
        GameObject sphere =GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(1, 2, 3);
        sphere.AddComponent<Rigidbody>();
    }

}
