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
            // 1. Aquí aplicarías la resta de vida (necesitarás el script de salud de tu jugador)
            // SC_Health salud = jugador.GetComponent<SC_Health>();
            // if (salud != null) salud.QuitarVida(cantidadDano);
            Debug.Log($"¡Ouch! El jugador ha perdido {cantidadDano} vida/s.");

            // 2. Empuje leve
            Rigidbody rbJugador = jugador.GetComponent<Rigidbody>();
            if (rbJugador != null)
            {
                Vector3 direccionEmpuje = (jugador.transform.position - transform.position).normalized;
                rbJugador.AddForce(direccionEmpuje * fuerzaPequena, ForceMode.Impulse);
            }
        }
    }
}