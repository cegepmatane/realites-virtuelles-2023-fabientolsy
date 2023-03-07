using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(this.gameObject.name + " est entre en collision avec " + collision.name);

    }
}
