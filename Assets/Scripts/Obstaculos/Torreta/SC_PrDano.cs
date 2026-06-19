using UnityEngine;

namespace Obstaculos.Torreta
{
    public class SC_PrDano : SC_ProyectilBase
    {
        [Header("Efecto Variante: Daño")]
        [SerializeField] private float fuerzaPequena = 8f;
        [SerializeField] private int cantidadDano = 1;

        protected override void AplicarEfecto(GameObject jugador)
        {
            IHittable objetivo = jugador.GetComponent<IHittable>();
            
            if (objetivo != null)
            {
                objetivo.Damage(cantidadDano, transform);
                Debug.Log($"¡Ouch! El proyectil ha quitado {cantidadDano} de vida.");
            }
            
            Rigidbody rbJugador = jugador.GetComponent<Rigidbody>();
            
            if (rbJugador == null) return;
            
            Vector3 direccionEmpuje = (jugador.transform.position - transform.position).normalized;
            // Añadimos un pequeño salto hacia arriba para que el empuje se note más
            direccionEmpuje.y = 0.5f; 
            rbJugador.AddForce(direccionEmpuje * fuerzaPequena, ForceMode.Impulse);
        }
    }
}