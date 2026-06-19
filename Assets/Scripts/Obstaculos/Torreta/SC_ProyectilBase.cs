using UnityEngine;

namespace Obstaculos.Torreta
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class SC_ProyectilBase : MonoBehaviour
    {
        [Header("Ajustes Base")]
        [SerializeField] protected float velocidadBala = 10f;
        [SerializeField] protected float tiempoVida = 3f;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
    
        private void OnEnable()
        {
            rb.linearVelocity = transform.forward * velocidadBala;
            Invoke(nameof(Desactivar), tiempoVida);
        }

        private void OnDisable()
        {
            CancelInvoke();
            rb.linearVelocity = Vector3.zero;
            // se para la objeto para que
            // al volver a dispararse no acumule la velocidad anterior
        }

        private void Desactivar()
        {
            gameObject.SetActive(false);
        }

        // Método abstracto: Permite a las hijas a decidir qué pasa al chocar
        protected abstract void AplicarEfecto(GameObject jugador);

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AplicarEfecto(other.gameObject);
                Desactivar();
            }
            else if (!other.CompareTag("Proyectil")) // las balas se ignoran
            {
                Desactivar();
            }
        }
    }
}