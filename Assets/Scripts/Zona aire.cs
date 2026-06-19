using System;
using UnityEngine;

public class Zonaaire : MonoBehaviour
{
    /*private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
        }
    }*/
    //Tecnicamente puede hacerse asi, pero desde el punto de programación hacer una variable asi,
    
    //iria en contra de la programación orientada a objetos

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
            otherRb.AddForce(new Vector3(120f,50,0) , ForceMode.Force);
            
        }
    }
}
