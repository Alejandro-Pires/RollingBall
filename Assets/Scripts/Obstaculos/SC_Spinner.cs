using UnityEngine;
using UnityEngine.Serialization;

public class GCylinder : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 200f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(Vector3.left * rotateSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
