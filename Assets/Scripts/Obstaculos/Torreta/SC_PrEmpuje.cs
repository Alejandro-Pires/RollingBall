using UnityEngine;

namespace Obstaculos.Torreta
{
    public class SC_PrEmpuje : SC_ProyectilBase
    {
        [Header("Efecto Variante: Empuje")]
        [SerializeField] private float fuerzaEmpuje = 25f;

        protected override void AplicarEfecto(GameObject jugador)
        {
            Rigidbody rbJugador = jugador.GetComponent<Rigidbody>();
            
            if (rbJugador == null) return;
            // A la dirección de empuje se le suma un poco de Y para levantar al player del suelo
            Vector3 direccionEmpuje = (jugador.transform.position - transform.position).normalized;
            direccionEmpuje.y = 0.5f; 
            
            rbJugador.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}