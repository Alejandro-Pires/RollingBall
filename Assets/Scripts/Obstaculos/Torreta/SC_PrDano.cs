using UnityEngine;

namespace Obstaculos.Torreta
{
    public class SC_PrDano : SC_ProyectilBase
    {
        [Header("Efecto Variante: Daño")]
        [SerializeField] private float fuerzaPequena = 8f;
        [SerializeField] private float cantidadDano = 1f;

        protected override void AplicarEfecto(GameObject jugador)
        {
            IHittable objetivo = jugador.GetComponentInChildren<IHittable>();
            
            if (objetivo != null)
            {
                objetivo.Damage(cantidadDano, transform);
                Debug.Log($"¡Ouch! El proyectil ha quitado {cantidadDano} de vida.");
            }
            
            Rigidbody rbJugador = jugador.GetComponent<Rigidbody>();
            
            if (rbJugador == null) return;
            
            Vector3 direccionEmpuje = (jugador.transform.position - transform.position).normalized;
            direccionEmpuje.y = 0.5f; 
            rbJugador.AddForce(direccionEmpuje * fuerzaPequena, ForceMode.Impulse);
        }
    }
}