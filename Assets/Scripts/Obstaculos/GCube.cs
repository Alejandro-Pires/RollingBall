using UnityEngine;
using UnityEngine.Serialization;

public class GCube : MonoBehaviour
{
    [FormerlySerializedAs("giro")] [SerializeField] float velocidad;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * velocidad * Time.deltaTime, Space.World);;
    }
}
