using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionCollision : MonoBehaviour
{
    [Header("Mur a desactiver")]
    public GameObject mur;

    [Header("RigidBody avec la graviter a activer")]
    public Rigidbody rb;


    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name + " est entre en collision avec " + this.gameObject.name);
        if (collision.transform.parent.name == "Left Hand" || collision.transform.parent.name == "Right Hand")
        {
            Debug.Log("Desactivation du mur");
            mur.SetActive(false);

            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}