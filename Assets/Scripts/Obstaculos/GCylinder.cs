using UnityEngine;

public class GCylinder : MonoBehaviour
{
    [SerializeField] float rotateForce;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(Vector3.up * rotateForce, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
