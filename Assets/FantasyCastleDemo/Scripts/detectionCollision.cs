using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionCollision : MonoBehaviour
{
    [Header("Mur a desactiver")]
    public GameObject mur;

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name + " est entre en collision avec " + this.gameObject.name);
        if (collision.name == "Left Hand" || collision.name == "Right Hand")
        {
            Debug.Log("Desactivation du mur");
            mur.SetActive(false);
        }
    }
}