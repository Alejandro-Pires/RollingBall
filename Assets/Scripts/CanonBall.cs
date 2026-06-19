using System;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    int force = 20;
    private Rigidbody rb;
    Vector3 forceVector = new Vector3(1, 0, 0).normalized;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(forceVector * force * Time.deltaTime, ForceMode.Acceleration);
    }
}
