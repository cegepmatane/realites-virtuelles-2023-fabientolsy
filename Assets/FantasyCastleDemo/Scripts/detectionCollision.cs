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
        if (collision.name == "hands:b_l_index3")
        {
            Debug.Log("Desactivation du mur");
            mur.SetActive(false);
        }
    }
}