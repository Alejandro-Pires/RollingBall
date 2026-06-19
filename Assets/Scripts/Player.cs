using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float fuerza = 10f;
    [SerializeField] private float saltoFuerza = 5f;

    [Header("Detección de Suelo")]
    [SerializeField] private float distanciaSuelo = 0.6f;
    [SerializeField] private LayerMask capaSuelo;

    private Rigidbody rb;
    private float hInput;
    private float vInput;
    private bool quiereSaltar; //comprobador de seguridad (evitar el salto infitino)

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //1. Los INPUT siempre van en Update para no perder frames de pulsación
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        // se registra la intención de salto cuando toca el suelo
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnElSuelo())
        {
            quiereSaltar = true;
        }
    }

    private void FixedUpdate()
    {
        // 2. FÍSICAS siempre van en FixedUpdate para que sean estables
        MovimientoBola();
        GestionarSalto();
    }

    private void MovimientoBola()
    {
        Vector3 movimiento = new Vector3(hInput, 0f, vInput).normalized;
        rb.AddForce(movimiento * fuerza, ForceMode.Force);
    }

    private void GestionarSalto()
    {
        if (quiereSaltar)
        {
            rb.AddForce(Vector3.up * saltoFuerza, ForceMode.Impulse);
            quiereSaltar = false;
        }
    }
    
    private bool EstaEnElSuelo()
    {
        // Lanza un rayo invisible hacia abajo desde el centro de la bola
        return Physics.Raycast(transform.position, Vector3.down, distanciaSuelo, capaSuelo);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = EstaEnElSuelo() ? Color.green : Color.red;
        
        Gizmos.DrawRay(transform.position, Vector3.down * distanciaSuelo);
    }
}